using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cook_Book.Helper;
using Cook_Book.Services;
using Cook_Book.UI;
using DataAccessLayer.CustomQueryResults;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Logging;
using DomainModel.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Nutrition_FitnessApp.Services;

namespace Nutrition_FitnessApp.UI
{
    public partial class RecipesForm : Form
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeTypeRepository _recipeTypeRepository;
        private List<RecipesWithTypes> _cachedRecipes;
        private List<RecipeType> _recipeTypes;
        private readonly IServiceProvider _serviceProvider;
        private int _recipeToEditId;
        private int _selectedFilterId;
        private byte[]? _selectedImageBytes = null;

        public RecipesForm(IRecipeRepository recipeRepository, IRecipeTypeRepository recipeTypeRepository, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _recipeRepository = recipeRepository;
            _recipeTypeRepository = recipeTypeRepository;
            _serviceProvider = serviceProvider;

            ApplyStyles(ThemeChanger.Instance.CurrentTheme);
        }

        private async void RecipesForm_Load(object sender, EventArgs e)
        {
            ImageBox.Image = ImageHelper.placeHolderImage;
            ImageBox.SizeMode = PictureBoxSizeMode.StretchImage;

            _selectedFilterId = 0;
            AddRecipeBtn.Visible = true;
            EditRecipeBtn.Visible = false;

            _recipeTypes = await _recipeTypeRepository.GetRecipeTypes();
            _cachedRecipes = await _recipeRepository.GetRecipes();
            CustomizeGridAppearance(ThemeChanger.Instance.CurrentTheme);
            RefreshRecipeTypes();
            FilterCbx();
            FilterAndRefreshGrid();
        }

        private void ClearAllFields()
        {
            NameTxt.Text = string.Empty;
            DescriptionTxt.Text = string.Empty;
            RecipeTypeCbx.SelectedIndex = 0;
            _selectedImageBytes = null;
            ImageBox.Image = ImageHelper.placeHolderImage;

            AddRecipeBtn.Visible = true;
            EditRecipeBtn.Visible = false;
        }

        private void CustomizeGridAppearance(int? theme = 1)
        {
            RecipesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RecipesGrid.RowHeadersVisible = false;
            RecipesGrid.AutoGenerateColumns = false;

            JObject themeConfig = themeConfigManager.LoadThemeConfig(theme);

            DataGridViewColumn[] column = new DataGridViewColumn[7];
            column[0] = new DataGridViewTextBoxColumn { DataPropertyName = "Id", Visible = false };
            column[1] = new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name" };
            column[2] = new DataGridViewTextBoxColumn { DataPropertyName = "Description", HeaderText = "Description" };
            column[3] = new DataGridViewTextBoxColumn { DataPropertyName = "Type", HeaderText = "Type" };

            column[4] = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "EditBtn",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = ColorTranslator.FromHtml(themeConfig?["primaryBtnBgr"]?.ToString() ?? "#007BFF"),
                    ForeColor = ColorTranslator.FromHtml(themeConfig?["primaryBtnFgr"]?.ToString() ?? "#fff"),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };
            column[5] = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "DeleteBtn",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = ColorTranslator.FromHtml(themeConfig?["secondaryBtnBgr"]?.ToString() ?? "#007BFF"),
                    ForeColor = ColorTranslator.FromHtml(themeConfig?["secondaryBtnFgr"]?.ToString() ?? "#fff"),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };
            column[6] = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "IngredientBtn",
                Text = "Ingredient",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = ColorTranslator.FromHtml(themeConfig?["tertiaryBtnBgr"]?.ToString() ?? "#007BFF"),
                    ForeColor = ColorTranslator.FromHtml(themeConfig?["tertiaryBtnFgr"]?.ToString() ?? "#fff"),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            RecipesGrid.Columns.Clear();
            RecipesGrid.Columns.AddRange(column);
        }

        private async void RecipesGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            RecipesWithTypes clickedData = (RecipesWithTypes)RecipesGrid.Rows[e.RowIndex].DataBoundItem;

            if (e.RowIndex >= 0 && e.ColumnIndex == RecipesGrid.Columns["EditBtn"].Index)
            {
                fillFormForEdit(clickedData);
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == RecipesGrid.Columns["DeleteBtn"].Index)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this recipe?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _recipeRepository.DeleteRecipe(clickedData.Id);
                    _cachedRecipes = await _recipeRepository.GetRecipes();
                    FilterAndRefreshGrid();

                    if (_recipeToEditId == clickedData.Id)
                    {
                        ClearAllFields();
                        AddRecipeBtn.Visible = true;
                        EditRecipeBtn.Visible = false;
                        _recipeToEditId = 0; // Reset the edit ID
                    }
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == RecipesGrid.Columns["IngredientBtn"].Index)
            {
                RecipeIngredientsForm startForm = _serviceProvider.GetRequiredService<RecipeIngredientsForm>();
                startForm.RecipeName = clickedData.Name;
                startForm.RecipeId = clickedData.Id;
                startForm.ShowDialog();
            }
        }
        private void fillFormForEdit(RecipesWithTypes clickedData)
        {
            _recipeToEditId = clickedData.Id;
            NameTxt.Text = clickedData.Name;
            DescriptionTxt.Text = clickedData.Description;
            if (clickedData.Image != null)
            {
                ImageBox.Image = ImageHelper.ConvertFromDbImage(clickedData.Image);
                _selectedImageBytes = clickedData.Image;
            }
            else
            {
                ImageBox.Image = ImageHelper.placeHolderImage;
            }

            // Used SelectedValue instead of SelectedIndex to set the correct RecipeType
            RecipeTypeCbx.SelectedValue = clickedData.RecipeTypeId;

            AddRecipeBtn.Visible = false;
            EditRecipeBtn.Visible = true;
        }

        private async void EditRecipeBtn_Click(object sender, EventArgs e)
        {
            if (!isValid("ignore"))
                return;

            byte[]? image = _selectedImageBytes != null ? _selectedImageBytes : null;
            int recipeTypeId = (int)RecipeTypeCbx.SelectedValue;
            Recipe recipeToEdit = new Recipe(NameTxt.Text, DescriptionTxt.Text, image, recipeTypeId, _recipeToEditId);

            EditRecipeBtn.Enabled = false;
            await _recipeRepository.UpdateRecipe(recipeToEdit);
            _cachedRecipes = await _recipeRepository.GetRecipes();
            EditRecipeBtn.Enabled = true;

            AddRecipeBtn.Visible = true;
            EditRecipeBtn.Visible = false;
            _recipeToEditId = 0;
            ClearAllFields();
            FilterAndRefreshGrid();
        }
        private void RefreshRecipeTypes()
        {
            RecipeTypeCbx.DataSource = _recipeTypes;
            RecipeTypeCbx.DisplayMember = "Name";
            RecipeTypeCbx.ValueMember = "Id"; // Important for .SelectedValue
        }
        private void FilterCbx()
        {
            List<RecipeType> allRecipeTypes = new List<RecipeType>()
            {
                new RecipeType { Name="All Recipe Types", Id = 0}
            };

            allRecipeTypes.AddRange(_recipeTypes);

            RecipeFilterCbx.DataSource = allRecipeTypes;
            RecipeFilterCbx.DisplayMember = "Name";
            RecipeFilterCbx.ValueMember = "Id";

            RecipeFilterCbx.SelectedIndex = 0; // Set default selection 
        }

        private async void AddRecipeBtn_Click(object sender, EventArgs e)
        {
            if (!isValid())
                return;

            int recipeTypeId = (int)RecipeTypeCbx.SelectedValue;

            byte[]? image = _selectedImageBytes != null ? _selectedImageBytes : null;
            Recipe recipeToInsert = new Recipe(NameTxt.Text, DescriptionTxt.Text, image, recipeTypeId);

            AddRecipeBtn.Enabled = false;
            await _recipeRepository.InsertRecipes(recipeToInsert);
            _cachedRecipes = await _recipeRepository.GetRecipes();
            AddRecipeBtn.Enabled = true;

            FilterAndRefreshGrid();
            ClearAllFields();
        }

        private bool isValid(string? ignore = null)
        {
            bool valid = true;
            string message = string.Empty;

            // short-circuit to avoid unneccesary loops
            if (ignore == null)
            {
                string name = NameTxt.Text.ToLower().Trim();
                if (_cachedRecipes.Any(r => r.Name.ToLower() == name))
                {
                    MessageBox.Show("Recipe with name exist.", "Duplicate recipe!");
                    return false;
                }
            }

            if (string.IsNullOrEmpty(NameTxt.Text.Trim()) && string.IsNullOrEmpty(DescriptionTxt.Text))
            {
                message = "Please fill the Name and Description.";
                valid = false;
            }
            else if (string.IsNullOrEmpty(NameTxt.Text.Trim()))
            {
                message = "Please provide the Name.";
                valid = false;
            }
            else if (string.IsNullOrEmpty(DescriptionTxt.Text.Trim()))
            {
                message = "Please provide the Description.";
                valid = false;
            }

            if (!valid)
            {
                MessageBox.Show(message, "Form not valid!");
            }

            return valid;
        }

        private void ClearAllFieldsBtn_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void AddRecipeTypeBtn_Click(object sender, EventArgs e)
        {
            // Open the form once the button is clicked and register it in 'program.cs'
            RecipeTypeForm startForm = _serviceProvider.GetRequiredService<RecipeTypeForm>();

            // startForm.FormClosed += OnRecipeTypeFormClosed; Lamda expression to handle form closed event
            startForm.FormClosed += async (sender, e) =>
            {
                _recipeTypes = await _recipeTypeRepository.GetRecipeTypes();
                RefreshRecipeTypes();
                FilterCbx();
            };

            startForm.ShowDialog();
        }

        private void RecipeFilterCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cachedRecipes != null && _cachedRecipes.Any())
                FilterAndRefreshGrid();
        }

        private void FilterAndRefreshGrid()
        {
            try
            {
                RecipeType seletedItem = RecipeFilterCbx.SelectedItem as RecipeType;

                if (seletedItem == null)
                {
                    // Show all recipes if selected item is null
                    RecipesGrid.DataSource = _cachedRecipes?.ToList() ?? new List<RecipesWithTypes>();
                    return;
                }

                _selectedFilterId = seletedItem.Id;

                RecipesGrid.DataSource = _selectedFilterId == 0 ? _cachedRecipes : _cachedRecipes.Where(r => r.RecipeTypeId == _selectedFilterId).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while filtering recipes: ", "Error");
                Logger.Log(ex.Message, DateTime.Now);
            }
        }

        private void ImageBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select an Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Multiselect = false
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    ImageBox.Image = Image.FromFile(selectedImagePath);
                    _selectedImageBytes = ImageHelper.ConvertToDbImage(selectedImagePath);
                }
            }
        }

        private void removeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageBox.Image = ImageHelper.placeHolderImage;
            _selectedImageBytes = null; // Clear the selected image bytes
        }

        private void ApplyStyles(int? theme = 1)
        {
            JObject themeConfig = themeConfigManager.LoadThemeConfig(theme);

            string primaryBgr = themeConfig?["primaryBgr"]?.ToString() ?? "#FFFFFF";
            string secondaryBgr = themeConfig?["secondaryBgr"]?.ToString() ?? "#F0F0F0";
            string primaryFgr = themeConfig?["primaryFgr"]?.ToString() ?? "#fff";

            // buttons color
            string primaryBtnBgr = themeConfig?["primaryBtnBgr"]?.ToString() ?? "#007BFF";
            string secondaryBtnBgr = themeConfig?["secondaryBtnBgr"]?.ToString() ?? "#6C757D";
            string tertiaryBtnBgr = themeConfig?["tertiaryBtnBgr"]?.ToString() ?? "#28A745";
            string primaryBtnFgr = themeConfig?["primaryBtnFgr"]?.ToString() ?? "#fff";
            string secondaryBtnFgr = themeConfig?["secondaryBtnFgr"]?.ToString() ?? "#fff";
            string tertiaryBtnFgr = themeConfig?["tertiaryBtnFgr"]?.ToString() ?? "#fff";
            string inputBgr = themeConfig?["inputBgr"]?.ToString() ?? "#2b3b53";

            LeftPanel.BackColor = ColorTranslator.FromHtml(primaryBgr);
            RightPanel.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            NameLbl.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            TypeLbl.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            DescriptionLbl.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            ImageLbl.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            NameTxt.BackColor = ColorTranslator.FromHtml(inputBgr);
            DescriptionTxt.BackColor = ColorTranslator.FromHtml(inputBgr);
            RecipeFilterCbx.BackColor = ColorTranslator.FromHtml(inputBgr);

            NameLbl.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            TypeLbl.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            DescriptionLbl.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            ImageLbl.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            NameTxt.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            DescriptionTxt.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            RecipeFilterCbx.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);

            AddRecipeBtn.BackColor = ColorTranslator.FromHtml(primaryBtnBgr);
            EditRecipeBtn.BackColor = ColorTranslator.FromHtml(primaryBtnBgr);
            ClearAllFieldsBtn.BackColor = ColorTranslator.FromHtml(secondaryBtnBgr);
            AddRecipeTypeBtn.BackColor = ColorTranslator.FromHtml(primaryBtnBgr);

            AddRecipeBtn.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            EditRecipeBtn.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            ClearAllFieldsBtn.ForeColor = ColorTranslator.FromHtml(secondaryBtnFgr);
            AddRecipeTypeBtn.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);

            StyleComboBox(RecipeTypeCbx, inputBgr, primaryBtnFgr, primaryBgr, primaryBtnFgr);
            StyleComboBox(RecipeFilterCbx, inputBgr, primaryBtnFgr, secondaryBgr, primaryBtnFgr);

            RecipesGrid.BackgroundColor = ColorTranslator.FromHtml(primaryBgr);
            RecipesGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            RecipesGrid.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(primaryFgr);

            RecipesGrid.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(primaryBgr);
            RecipesGrid.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            RecipesGrid.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
        }

        private void StyleComboBox(ComboBox comboBox, string backColor, string foreColor, string selectionBgr, string selectionFgr)
        {            
            comboBox.BackColor = ColorTranslator.FromHtml(backColor);
            comboBox.ForeColor = ColorTranslator.FromHtml(foreColor);

            comboBox.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox.FlatStyle = FlatStyle.Flat; 

            comboBox.DrawItem -= ComboBox_DrawItem;
            comboBox.DropDownClosed -= ComboBox_DropDownClosed;
            comboBox.DrawItem += ComboBox_DrawItem;
            comboBox.DropDownClosed += ComboBox_DropDownClosed;

            comboBox.Tag = new
            {
                BackColor = ColorTranslator.FromHtml(backColor),
                ForeColor = ColorTranslator.FromHtml(foreColor),
                SelectionBackColor = ColorTranslator.FromHtml(selectionBgr),
                SelectionForeColor = ColorTranslator.FromHtml(selectionFgr),
                HoverBackColor = ColorTranslator.FromHtml(selectionBgr),
                HoverForeColor = ColorTranslator.FromHtml(selectionFgr)
            };
        }
        private void ComboBox_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (sender is not ComboBox comboBox) return;

            var colors = comboBox.Tag as dynamic;
            if (colors == null) return;

            e.DrawBackground();

            if (e.Index < 0)
            {
                using(Brush backBrush = new SolidBrush(colors.BackColor),
                     foreBrush = new SolidBrush(colors.ForeColor))
                {
                    e.Graphics.FillRectangle(backBrush, e.Bounds);
                    e.Graphics.DrawString(comboBox.Text, e.Font, foreBrush, e.Bounds);
                }
                return;
            }

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color backColor, foreColor;

            backColor = isSelected ? ColorTranslator.FromHtml("#2C4E78") : colors.BackColor;
            foreColor = isSelected ? ColorTranslator.FromHtml("#ffffff") : colors.ForeColor;

            using (Brush backBrush = new SolidBrush(backColor),
                   foreBrush = new SolidBrush(foreColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                e.Graphics.DrawString(comboBox.Items[e.Index].ToString() ?? string.Empty, e.Font, foreBrush, e.Bounds);
            }

            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
            {
                e.DrawFocusRectangle();
            }
        }

        private void ComboBox_DropDownClosed(object? sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                comboBox.Invalidate();
            }
        }


        private void theme2Btn_Click(object sender, EventArgs e)
        {
            ThemeChanger.Instance.CurrentTheme = 2;
            ThemeChanger.Instance.ThemeChanged(ThemeChanger.Instance.CurrentTheme);
            ApplyStyles(ThemeChanger.Instance.CurrentTheme);
            CustomizeGridAppearance(ThemeChanger.Instance.CurrentTheme);
        }

        private void theme1Btn_Click(object sender, EventArgs e)
        {
            ThemeChanger.Instance.CurrentTheme = 1;
            ThemeChanger.Instance.ThemeChanged(ThemeChanger.Instance.CurrentTheme);
            ApplyStyles(ThemeChanger.Instance.CurrentTheme);
            CustomizeGridAppearance(ThemeChanger.Instance.CurrentTheme);
        }
    }
}
