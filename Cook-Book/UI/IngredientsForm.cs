using System.Diagnostics;
using System.DirectoryServices;
using System.Threading.Tasks;
using Cook_Book.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DomainModels.Models;
using Newtonsoft.Json.Linq;

namespace Cook_Book.UI
{
    public partial class IngredientsForm : Form
    {
        readonly IIngredientsRepository _ingredientsRepository;

        // This will cache the Ingredients from the db to avoid unncessary requests
        private List<Ingredient> _ingredients = new();
        private List<Ingredient> _matchingIngredients = new();
        private string _currentSort = "None";

        private int _ingredientToEditId = 0;

        public IngredientsForm(IIngredientsRepository ingredientsRepository)
        {
            InitializeComponent();

            _ingredientsRepository = ingredientsRepository;

            // Used Lamda expression to subsribe to the error.
            _ingredientsRepository.ErrorOccurred += exMessage =>
                MessageBox.Show(exMessage, "Error");
            ApplyStyles(ThemeChanger.Instance.CurrentTheme);
        }

        private async void IngredientsForm_Load(object sender, EventArgs e)
        {
            EditIngredientsBtn.Visible = false;
            AddIngredientBtn.Visible = true;
            _ingredients = await _ingredientsRepository.GetIngredients();
            SortByComboBox();
            SearchAndRefreshResult();
            CustomizeGridAppearance(ThemeChanger.Instance.CurrentTheme);
        }

        private async void AddIngredientBtn_Click(object sender, EventArgs e)
        {
            if (!isValid())
                return;

            Ingredient ingredients = new Ingredient(NameTxt.Text, TypeTxt.Text, WeightNum.Value, KcalPer100gNum.Value, PricePer100gNum.Value);

            AddIngredientBtn.Enabled = false;
            await _ingredientsRepository.InsertIngredients(ingredients);
            AddIngredientBtn.Enabled = true;

            // Update the cached ingredient
            _ingredients = await _ingredientsRepository.GetIngredients();

            SearchAndRefreshResult();
            ClearInputFields();
        }

        private void CustomizeGridAppearance(int? theme = 1)
        {
            IngredientsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            IngredientsDataGrid.AutoGenerateColumns = false;

            JObject themeConfig = themeConfigManager.LoadThemeConfig(theme);

            DataGridViewColumn[] column = new DataGridViewColumn[8];
            column[0] = new DataGridViewTextBoxColumn() { DataPropertyName = "Id", Visible = false };
            column[1] = new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "Name" };
            column[2] = new DataGridViewTextBoxColumn() { DataPropertyName = "Type", HeaderText = "Type" };
            column[3] = new DataGridViewTextBoxColumn() { DataPropertyName = "Weight", HeaderText = "Weight" };
            column[4] = new DataGridViewTextBoxColumn() { DataPropertyName = "KcalPer100g", HeaderText = "Kcal (100g)" };
            column[5] = new DataGridViewTextBoxColumn() { DataPropertyName = "PricePer100g", HeaderText = "Price (100g)" };

            // Edit button column
            column[6] = new DataGridViewButtonColumn()
            {
                HeaderText = "",
                Name = "EditBtn",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = ColorTranslator.FromHtml(themeConfig["primaryBtnBgr"]?.ToString() ?? "#007bff"),
                    ForeColor = ColorTranslator.FromHtml(themeConfig["primaryBtnFgr"]?.ToString() ?? "#ffffff"),
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                }
            };

            // Delete button column
            column[7] = new DataGridViewButtonColumn()
            {
                HeaderText = "",
                Name = "DeleteBtn",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = ColorTranslator.FromHtml(themeConfig["secondaryBtnBgr"]?.ToString() ?? "#6c757d"),
                    ForeColor = ColorTranslator.FromHtml(themeConfig["secondaryBtnFgr"]?.ToString() ?? "#ffffff"),
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                }
            };

            IngredientsDataGrid.RowHeadersVisible = false;
            IngredientsDataGrid.Columns.Clear();
            IngredientsDataGrid.Columns.AddRange(column);
        }

        private async void IngredientsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Ingredient clickedData = (Ingredient)IngredientsDataGrid.Rows[e.RowIndex].DataBoundItem;
            if(e.RowIndex >= 0 && e.ColumnIndex == IngredientsDataGrid.Columns["DeleteBtn"].Index)
            {
                // Guard clause
                var result = MessageBox.Show("Are you sure you want to delete ingredient", "Delete Ingredient", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await _ingredientsRepository.DeleteIngredients(clickedData);
                    _ingredients = await _ingredientsRepository.GetIngredients();
                    SearchAndRefreshResult();
                    if(_ingredientToEditId == clickedData.Id)
                    {
                        ClearInputFields();
                        _ingredientToEditId = 0;// Reset the edit Id
                    }
                }
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == IngredientsDataGrid.Columns["EditBtn"].Index)
                fillFormEdit(clickedData);          
        }

        private void fillFormEdit(Ingredient clickedData)
        {
            _ingredientToEditId = clickedData.Id;

            NameTxt.Text = clickedData.Name;
            TypeTxt.Text = clickedData.Type;
            WeightNum.Value = clickedData.Weight;
            KcalPer100gNum.Value = clickedData.KcalPer100g;
            PricePer100gNum.Value = clickedData.PricePer100g;

            EditIngredientsBtn.Visible = true;
            AddIngredientBtn.Visible = false;
        }
        private async void EditIngredientsBtn_Click(object sender, EventArgs e)
        {
            if (!isValid("ignore"))
                return;

            // Using a Constuctor instead of Object initializer
            Ingredient ingeredientsToEdit = new Ingredient(NameTxt.Text, TypeTxt.Text,WeightNum.Value,KcalPer100gNum.Value,PricePer100gNum.Value, _ingredientToEditId);

            EditIngredientsBtn.Enabled = false;
            await _ingredientsRepository.UpdateIngredients(ingeredientsToEdit);
         // Update the cached ingredient
            _ingredients = await _ingredientsRepository.GetIngredients();
            EditIngredientsBtn.Enabled = true;
            EditIngredientsBtn.Visible = false;
            AddIngredientBtn.Visible = true;


            ClearInputFields();            
            SearchAndRefreshResult();
            _ingredientToEditId = 0;
        }

        private void ClearInputFields()
        {
            TypeTxt.Text = string.Empty;
            NameTxt.Text = string.Empty;
            WeightNum.Value = 1;
            KcalPer100gNum.Value = 0;
            PricePer100gNum.Value = 0;

            EditIngredientsBtn.Visible = false;
            AddIngredientBtn.Visible = true;
            _ingredientToEditId = 0;
        }
        private void ClearAllFields()
        {
            TypeTxt.Text = string.Empty;
            NameTxt.Text = string.Empty;
            WeightNum.Value = 1;
            KcalPer100gNum.Value = 0;
            PricePer100gNum.Value = 0;
            SearchTxt.Text = string.Empty;

            EditIngredientsBtn.Visible = false;
            AddIngredientBtn.Visible = true;
            _ingredientToEditId = 0;
        }

        private bool isValid(string? ignore = null)
        {
            // Short-cicuit evaluation to avoid unneccessary looping
            if (ignore == null)
            {
                // Used LINQ Expression
                if (_ingredients.Any(i => i.Name.ToLower() == NameTxt.Text.ToLower().Trim()))
                {
                    MessageBox.Show("Ingredient with name exist.", "Error");
                    return false;
                }
            }


            if (string.IsNullOrEmpty(NameTxt.Text.Trim()) || string.IsNullOrEmpty(TypeTxt.Text.Trim()) || PricePer100gNum.Value <= 0)
            {
                MessageBox.Show("Please fill all fields", "Error");
                return false;
            }

            return true;
        }

        private void ClearAllFieldsBtn_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private async void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            int lengthBeforePause = SearchTxt.Text.Length;
            await Task.Delay(650);
            int lengthAfterPause = SearchTxt.Text.Length;

            if (lengthBeforePause == lengthAfterPause)
                SearchAndRefreshResult();
        }

        private void SearchAndRefreshResult()
        {
            string searchIngredient = SearchTxt.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchIngredient))
                _matchingIngredients = _ingredients;
            else
                _matchingIngredients = _ingredients.Where(i => i.Name.ToLower().Contains(searchIngredient)).ToList();

            _matchingIngredients = _currentSort switch
            {
                "Name" => _matchingIngredients.OrderBy(i => i.Name).ToList(),
                "Price" => _matchingIngredients.OrderBy(i => i.PricePer100g).ThenBy(i => i.Name).ToList(),
                "Type" => _matchingIngredients.OrderBy(i => i.Type).ThenBy(i => i.Name).ToList(),
                "Weight" => _matchingIngredients.OrderBy(i => i.Weight).ThenBy(i => i.Name).ToList(),
                "Kcal" => _matchingIngredients.OrderBy(i => i.KcalPer100g).ThenBy(i => i.Name).ToList(),
                "None" or _ => _matchingIngredients
            };

            IngredientsDataGrid.DataSource = null;
            IngredientsDataGrid.DataSource = _matchingIngredients;
        }

        private void SortByComboBox()
        {
            SortByCbx.Items.AddRange(new string[]
            {
                "None",
                "Name",
                "Price",
                "Type",
                "Weight",
                "Kcal"
            });

            SortByCbx.SelectedIndex = 0;
        }

        private void SortByCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentSort = SortByCbx.SelectedItem?.ToString() ?? "None";

            SearchAndRefreshResult();
        }

        private void ApplyStyles(int? theme = 1)
        {
            JObject themeConfig = themeConfigManager.LoadThemeConfig(theme);

            string primaryBgr = themeConfig["primaryBgr"]?.ToString() ?? "#007bff";
            string secondaryBgr = themeConfig["secondaryBgr"]?.ToString() ?? "#6c757d";
            string primaryFgr = themeConfig["primaryFgr"]?.ToString() ?? "#ffffff";

            // buttons color
            string primaryBtnBgr = themeConfig["primaryBtnBgr"]?.ToString() ?? "#007bff";
            string secondaryBtnBgr = themeConfig["secondaryBtnBgr"]?.ToString() ?? "#6c757d";   
            string tertiaryBtnBgr = themeConfig["tertiaryBtnBgr"]?.ToString() ?? "#ffffff";
            string primaryBtnFgr = themeConfig["primaryBtnFgr"]?.ToString() ?? "#ffffff";
            string secondaryBtnFgr = themeConfig["secondaryBtnFgr"]?.ToString() ?? "#ffffff";
            string tertiaryBtnFgr = themeConfig["tertiaryBtnFgr"]?.ToString() ?? "#000000";
            string inputBgr = themeConfig["inputBgr"]?.ToString() ?? "#2b3b53";

            LeftPanel.BackColor = ColorTranslator.FromHtml(primaryBgr);
            RightPanel.BackColor = ColorTranslator.FromHtml(secondaryBgr);

            NameLbl.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            TypeLbl.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            WeightLbl.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            KcalLbl.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            PriceLbl.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            SortByLbl.BackColor = ColorTranslator.FromHtml(primaryBgr);

            NameTxt.BackColor = ColorTranslator.FromHtml(inputBgr);
            TypeTxt.BackColor = ColorTranslator.FromHtml(inputBgr);
            WeightNum.BackColor = ColorTranslator.FromHtml(inputBgr);
            KcalPer100gNum.BackColor = ColorTranslator.FromHtml(inputBgr);
            PricePer100gNum.BackColor = ColorTranslator.FromHtml(inputBgr);
            SearchTxt.BackColor = ColorTranslator.FromHtml(inputBgr);

            NameTxt.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            TypeTxt.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            WeightNum.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            KcalPer100gNum.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            PricePer100gNum.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            SearchTxt.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);

            NameLbl.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            TypeLbl.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            WeightLbl.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            KcalLbl.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            PriceLbl.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            SortByLbl.ForeColor = ColorTranslator.FromHtml(primaryFgr);

            AddIngredientBtn.BackColor = ColorTranslator.FromHtml(primaryBtnBgr);
            EditIngredientsBtn.BackColor = ColorTranslator.FromHtml(primaryBtnBgr);
            ClearAllFieldsBtn.BackColor = ColorTranslator.FromHtml(secondaryBtnBgr);

            AddIngredientBtn.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            EditIngredientsBtn.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            ClearAllFieldsBtn.ForeColor = ColorTranslator.FromHtml(secondaryBtnFgr);

            StyleComboBox(SortByCbx, inputBgr, primaryBtnFgr, primaryBgr, primaryBtnFgr);

            IngredientsDataGrid.BackgroundColor = ColorTranslator.FromHtml(primaryBgr);        
           IngredientsDataGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(secondaryBgr);   
            IngredientsDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(primaryFgr);

            IngredientsDataGrid.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(primaryBgr);
            IngredientsDataGrid.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            IngredientsDataGrid.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
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
                using (Brush backBrush = new SolidBrush(colors.BackColor),
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

    }
}
