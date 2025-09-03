using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cook_Book.Helper;
using Cook_Book.Services;
using Cook_Book.ViewModel;
using DataAccessLayer.CustomQueryResults;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Logging;
using DomainModel.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Nutrition_FitnessApp.Services;

namespace Nutrition_FitnessApp.UI
{
    public enum RecipeAvailability { Available, Unavailable }
    public partial class FoodManagerForm : Form
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;

        private List<RecipeIngredientWithNameAndAmount> _recipeIngredientWithNameAndAmounts = new();
        private List<RecipeIngredientExtendedVM> _extendedRecipe = new();

        public int _selectedRecipeId;
        private FoodManagerCache _foodManagerCache;
        private DesktopFileWatcher _desktopFileWatcher;

        public FoodManagerForm(IRecipeRepository recipeRepository, IRecipeIngredientRepository recipeIngredientRepository, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _recipeRepository = recipeRepository;
            _recipeIngredientRepository = recipeIngredientRepository;

            _foodManagerCache = serviceProvider.GetRequiredService<FoodManagerCache>();
            _desktopFileWatcher = serviceProvider.GetRequiredService<DesktopFileWatcher>();

            // Observer design pattern: Subscriber
            _desktopFileWatcher.OnFileStatusChanged += OnFileStatusChanged;

            RecipesLbx.DrawMode = DrawMode.OwnerDrawFixed;

            ApplyStyles(ThemeChanger.Instance.CurrentTheme);
            this.Load += FoodManagerForm_Load;
        }

        private void OnFileStatusChanged(bool fileExists)
        {
            if (this.IsHandleCreated)
            {
                // this ensures that the UI update happens on the UI thread
                Invoke(new Action(() =>
                {
                    NotificationIcon.Visible = fileExists;
                }));
            }
        }

        private void errorLogger(string exMessage)
        {
            Logger.Log(exMessage, DateTime.Now);
        }

        private async void FoodManagerForm_Load(object sender, EventArgs e)
        {
            OnRightPanelFormLoad();
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PrepareFoodBtn.Visible = true;
            CreateShoppingListBtn.Visible = false;
            await _foodManagerCache.RefreshData();
            DisplayRecipes(RecipeAvailability.Available);
            GetRecipeId();
            DisplayRecipeDetails();
        }

        private void OnRightPanelFormLoad()
        {
            PrepareFoodBtn.Enabled = false;
            CreateShoppingListBtn.Enabled = false;
            foreach (Control ctrl in RightPanel.Controls)
            {
                ctrl.Visible = false;
            }
        }

        private void DisplayRecipes(RecipeAvailability recipeAvailability)
        {
            JObject themeConfig = themeConfigManager.LoadThemeConfig(2);

            RecipesLbx.DataSource = null;
            if (recipeAvailability == RecipeAvailability.Available)
            {
                RecipesLbx.DataSource = _foodManagerCache.AvailableRecipes;
                PrepareFoodBtn.Visible = true;
                CreateShoppingListBtn.Visible = false;

                RecipesLbx.DisplayMember = "Name";
                RecipesLbx.ValueMember = "Id";
            }
            else if (recipeAvailability == RecipeAvailability.Unavailable)
            {
                RecipesLbx.DataSource = _foodManagerCache.UnavilableRecipes;
                PrepareFoodBtn.Visible = false;
                CreateShoppingListBtn.Visible = true;

                RecipesLbx.DisplayMember = "Name";
                RecipesLbx.ValueMember = "Id";
            }

            if (RecipesLbx.Items.Count == 0)
            {
                ShowPanelDetails(false);
                CreateShoppingListBtn.Enabled = false;
                PrepareFoodBtn.Enabled = false;
                CreateShoppingListBtn.BackColor = ColorTranslator.FromHtml(themeConfig?["disabledTertiaryBtnBgr"]?.ToString() ?? "#d6c0ad");
                CreateShoppingListBtn.ForeColor = ColorTranslator.FromHtml(themeConfig?["disabledTertiaryBtnFgr"]?.ToString() ?? "#e0e0e0");
                PrepareFoodBtn.BackColor = ColorTranslator.FromHtml(themeConfig?["disabledPrimaryBtnBgr"]?.ToString() ?? "#9ba9a6");               
                PrepareFoodBtn.ForeColor = ColorTranslator.FromHtml(themeConfig?["disabledPrimaryBtnFgr"]?.ToString() ?? "#e0e0e0");
            }
            else if (RecipesLbx.Items.Count > 0)
            {
                RecipesLbx.SelectedIndex = 0;
                ShowPanelDetails(true);
                NotificationIcon.Visible = DesktopFileWatcher.CurrentFileStatus;
                CreateShoppingListBtn.Enabled = true;
                PrepareFoodBtn.Enabled = true;
                ApplyStyles(ThemeChanger.Instance.CurrentTheme);
            }
        }

        private void ShowPanelDetails(bool hasData)
        {
            foreach (Control ctrl in RightPanel.Controls)
            {
                if (ctrl == ItemsToDisplayLbl)
                    ctrl.Visible = !hasData;
                else
                    ctrl.Visible = hasData;
            }
        }

        private void DisplayRecipeDetails()
        {
            if (RecipesLbx.SelectedItem == null)
            {
                DescriptionTxt.Text = string.Empty;
                IngredientsLbx.DataSource = new List<Recipe>();
                PictureBox.Image = ImageHelper.placeHolderImage;
                return;
            }

            Recipe selectedRecipe = (Recipe)RecipesLbx.SelectedItem;
            DescriptionTxt.Text = selectedRecipe.Description;

            List<RecipeIngredientExtendedVM> recipeIngredientsExtendedVm = _foodManagerCache.GetIngredients(selectedRecipe.Id);

            IngredientsLbx.DataSource = null;
            IngredientsLbx.DataSource = recipeIngredientsExtendedVm;
            IngredientsLbx.DisplayMember = "NameWithMissingAmount";
            byte[]? imageBytes = selectedRecipe.Image;
            if (imageBytes != null && imageBytes.Length > 0)
            {
                PictureBox.Image = ImageHelper.ConvertFromDbImage(imageBytes);
            }
            else
            {
                PictureBox.Image = ImageHelper.placeHolderImage;
            }

            decimal totalKcal = 0;
            decimal totalPrice = 0;
            foreach (var i in _extendedRecipe)
            {
                totalKcal += (i.KcalPer100g / 100) * i.Amount;
                totalPrice += (i.PricePer100g / 100) * i.Amount;
            }

            if(totalKcal > 300)
                IconDisplay.Image = Properties.Resources.button;
            else
                IconDisplay.Image = Properties.Resources.check1;

            TotalCaloriesLbl.Text = Math.Round(totalKcal, 2).ToString();
            // The C2 will convert to currency with 2 decimal places
            TotalPriceLbl.Text = totalPrice.ToString("C2", new CultureInfo("en-KE")); // format as currency into KES
        }

        private void GetRecipeId()
        {
            if (RecipesLbx.SelectedItem == null)
            {
                _selectedRecipeId = 0;
                return;
            }
            Recipe selectedRecipe = (Recipe)RecipesLbx.SelectedItem;
            _selectedRecipeId = selectedRecipe.Id;
        }

        private void RecipesLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRecipeId(); // update the _selectedRecipeId
            _recipeIngredientWithNameAndAmounts = _foodManagerCache.GetIngredientNameAndAmount(_selectedRecipeId);
            _extendedRecipe = _foodManagerCache.GetIngredients(_selectedRecipeId);
            DisplayRecipeDetails();
        }

        private async void PrepareFoodBtn_Click(object sender, EventArgs e)
        {
            if (RecipesLbx.SelectedItem == null)
            {
                MessageBox.Show("Please select a recipe.");
                return;
            }

            Recipe selectedRecipe = (Recipe)RecipesLbx.SelectedItem;

            PrepareFoodBtn.Enabled = false;
            await _foodManagerCache.PrepareFood(selectedRecipe.Id);
            await _foodManagerCache.RefreshData();
            PrepareFoodBtn.Enabled = true;

            DisplayRecipes(RecipeAvailability.Available);

            _desktopFileWatcher.PreparedRecipesCounter++;
        }

        private void AvailableBtn_Click(object sender, EventArgs e)
        {
            DisplayRecipes(RecipeAvailability.Available);
        }

        private void UnavailableBtn_Click(object sender, EventArgs e)
        {
            DisplayRecipes(RecipeAvailability.Unavailable);
        }

        private void CreateShoppingListBtn_Click(object sender, EventArgs e)
        {
            if (RecipesLbx.SelectedItem == null)
            {
                MessageBox.Show("Please select a recipe.");
                return;
            }

            string shoppingList = "";
            foreach (Recipe recipe in _foodManagerCache.UnavilableRecipes)
            {
                shoppingList += $"\nMissing ingredients for {recipe.Name}\n";

                var recipeIngredients = _foodManagerCache.GetIngredients(recipe.Id);

                foreach (var ingredient in recipeIngredients)
                {
                    if (ingredient.MissingAmount != 0)
                        shoppingList += $"{ingredient.Name} {ingredient.MissingAmount}g \n";
                }
            }

            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "ShoppingList2.txt");

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    CreateShoppingListBtn.Enabled = false;
                    sw.Write(shoppingList);
                    MessageBox.Show("Write successful ✅");
                    CreateShoppingListBtn.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while creating the shopping list: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string exMessage = "Error happened while creating shopping list. " + ex.Message;
                errorLogger(exMessage);
            }
        }

        private void ApplyStyles(int? theme = 1)
        {
            JObject themeConfig = themeConfigManager.LoadThemeConfig(theme);

            string primaryBgr = themeConfig["primaryBgr"]?.ToString() ?? "#FFFFFF";
            string secondaryBgr = themeConfig["secondaryBgr"]?.ToString() ?? "#F0F0F0";
            string primaryFgr = themeConfig["primaryFgr"]?.ToString() ?? "#000000";

            // buttons Bgr color
            string primaryBtnBgr = themeConfig["primaryBtnBgr"]?.ToString() ?? "#007BFF";
            string secondaryBtnBgr = themeConfig["secondaryBtnBgr"]?.ToString() ?? "#6C757D";
            string tertiaryBtnBgr = themeConfig["tertiaryBtnBgr"]?.ToString() ?? "#28A745";
            string classicBtnBgr = themeConfig["classicBtnBgr"]?.ToString() ?? "#DC3545";

            // buttons Fgr color
            string primaryBtnFgr = themeConfig["primaryBtnFgr"]?.ToString() ?? "#FFFFFF";
            string secondaryBtnFgr = themeConfig["secondaryBtnFgr"]?.ToString() ?? "#FFFFFF";
            string tertiaryBtnFgr = themeConfig["tertiaryBtnFgr"]?.ToString() ?? "#FFFFFF";

            LeftPanel.BackColor = ColorTranslator.FromHtml(primaryBgr);
            RightPanel.BackColor = ColorTranslator.FromHtml(secondaryBgr);

            TotalCalories.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            TotalCaloriesLbl.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            TotalPrice.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            TotalPriceLbl.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            Healthy.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            Ingredients.ForeColor = ColorTranslator.FromHtml(primaryFgr);

            AvailableBtn.BackColor = ColorTranslator.FromHtml(primaryBtnBgr);
            AvailableBtn.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            UnavailableBtn.BackColor = ColorTranslator.FromHtml(secondaryBtnBgr);
            UnavailableBtn.ForeColor = ColorTranslator.FromHtml(secondaryBtnFgr);

            PrepareFoodBtn.BackColor = ColorTranslator.FromHtml(primaryBtnBgr);
            PrepareFoodBtn.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            CreateShoppingListBtn.BackColor = ColorTranslator.FromHtml(tertiaryBtnBgr);
            CreateShoppingListBtn.ForeColor = ColorTranslator.FromHtml(tertiaryBtnFgr);

            DescriptionTxt.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            DescriptionTxt.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            StyleListBox(RecipesLbx, primaryBgr, primaryBtnFgr, secondaryBgr, primaryBtnFgr);
            StyleListBox(IngredientsLbx, secondaryBgr, primaryBtnFgr, primaryBgr, primaryBtnFgr);

            ItemsToDisplayLbl.ForeColor = ColorTranslator.FromHtml("#940909");
        }

        private void StyleListBox(ListBox Lbx, string backColor, string foreColor, string selectionBgr, string selectionFgr)
        {
            Lbx.BackColor = ColorTranslator.FromHtml(backColor);
            Lbx.ForeColor = ColorTranslator.FromHtml(foreColor);

            // Enable custom drawing
            Lbx.DrawMode = DrawMode.OwnerDrawFixed;
            Lbx.DrawItem -= ListBox_DrawItem; // Unsubscribe if already subscribed
            Lbx.DrawItem += ListBox_DrawItem;

            Lbx.Tag = new
            {
                BackColor = ColorTranslator.FromHtml(backColor),
                ForeColor = ColorTranslator.FromHtml(foreColor),
                SelectionBackColor = ColorTranslator.FromHtml(selectionBgr),
                SelectionForeColor = ColorTranslator.FromHtml(selectionFgr)
            };
        }

        private void ListBox_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (sender is not ListBox listBox) return;

            var colors = listBox.Tag as dynamic;
            if(colors == null) return;

            e.DrawBackground();
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color backColor = isSelected ? colors.SelectionBackColor : colors.BackColor;
            Color foreColor = isSelected ? colors.SelectionForeColor : colors.ForeColor;

            using (Brush backBrush = new SolidBrush(backColor),
               foreBrush = new SolidBrush(foreColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                if (e.Index >= 0)
                {
                    string text = listBox.Items[e.Index].ToString() ?? string.Empty;
                    e.Graphics.DrawString(text, e.Font, foreBrush, e.Bounds);
                }
            }
            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
            {
                e.DrawFocusRectangle();
            }
        }

        private void NotificationIcon_MouseEnter(object sender, EventArgs e)
        {
            NotificationTooltip.Show("You need to shop for missing ingredients!", NotificationIcon, 0, -10);
        }

        private void NotificationIcon_MouseLeave(object sender, EventArgs e)
        {
            NotificationTooltip.Hide(NotificationIcon);
        }
    }
}
