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

namespace Cook_Book.UI
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
            this.Load += FoodManagerForm_Load;
        }

        private void OnFileStatusChanged(bool fileExists)
        {
            // this ensures that the UI update happens on the UI thread
            if (this.IsHandleCreated)
            {
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
            foreach(Control ctrl in RightPanel.Controls)
            {
                ctrl.Visible= false;
            }
        }

        private void DisplayRecipes(RecipeAvailability recipeAvailability)
        {
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
            }
            else
            {
                RecipesLbx.SelectedIndex = 0;
                ShowPanelDetails(true);
                NotificationIcon.Visible = DesktopFileWatcher.CurrentFileStatus;
                CreateShoppingListBtn.Enabled = true;
                PrepareFoodBtn.Enabled = true;
            }
        }

        private void ShowPanelDetails(bool hasData)
        {
            foreach(Control ctrl in RightPanel.Controls)
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
            foreach(Recipe recipe in _foodManagerCache.UnavilableRecipes)
            {
                shoppingList += $"\nMissing ingredients for {recipe.Name}\n";

                var recipeIngredients = _foodManagerCache.GetIngredients(recipe.Id);

                foreach(var ingredient in recipeIngredients)
                {
                    if(ingredient.MissingAmount != 0)
                        shoppingList += $"{ingredient.Name} {ingredient.MissingAmount}g \n";
                }
            }

            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "ShoppingList2.txt");

                using(StreamWriter sw = new StreamWriter(filePath))
                {
                    CreateShoppingListBtn.Enabled = false;
                    sw.Write(shoppingList);
                    MessageBox.Show("Write successful ✅");
                    CreateShoppingListBtn.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while creating the shopping list: " ,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string exMessage = "Error happened while creating shopping list. " + ex.Message;
                errorLogger(exMessage);
            }
        }       
    }
}
