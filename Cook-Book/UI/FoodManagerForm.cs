using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cook_Book.Helper;
using Cook_Book.ViewModel;
using DataAccessLayer.CustomQueryResults;
using DataAccessLayer.Interfaces;
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

        public FoodManagerForm(IRecipeRepository recipeRepository, IRecipeIngredientRepository recipeIngredientRepository, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _recipeRepository = recipeRepository;
            _recipeIngredientRepository = recipeIngredientRepository;

            _foodManagerCache = serviceProvider.GetRequiredService<FoodManagerCache>();

            this.Load += FoodManagerForm_Load;
        }

        private async void FoodManagerForm_Load(object sender, EventArgs e)
        {
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            await _foodManagerCache.RefreshData();
            DisplayRecipes(RecipeAvailability.Available);
            GetRecipeId();
            DisplayRecipeDetails();
        }

        private void DisplayRecipes(RecipeAvailability recipeAvailability)
        {
            RecipesLbx.DataSource = null;
            if (recipeAvailability == RecipeAvailability.Available)
            {
                RecipesLbx.DataSource = _foodManagerCache.AvailableRecipes;
                RecipesLbx.DisplayMember = "Name";
                RecipesLbx.ValueMember = "Id";
                RecipesLbx.SelectedIndex = 0;
            }
            else if (recipeAvailability == RecipeAvailability.Unavailable)
            {
                RecipesLbx.DataSource = _foodManagerCache.UnavilableRecipes;
                RecipesLbx.DisplayMember = "Name";
                RecipesLbx.ValueMember = "Id";
                RecipesLbx.SelectedIndex = 0;
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
            List<RecipeIngredientsVM> recipeIngredientsVMs = _recipeIngredientWithNameAndAmounts
                .Select(ri => new RecipeIngredientsVM(ri.Name, ri.IngredientId, ri.Amount))
                .ToList();

            IngredientsLbx.DataSource = null;
            IngredientsLbx.DataSource = recipeIngredientsVMs;
            IngredientsLbx.DisplayMember = "NameWithAmount";
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
                totalKcal += (i.KcalPer100g/100) * i.Amount;
                totalPrice += (i.PricePer100g / 100) * i.Amount;
            }

            TotalCaloriesLbl.Text = Math.Round(totalKcal,2).ToString();
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

        private async void RecipesLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRecipeId(); // update the _selectedRecipeId
            _recipeIngredientWithNameAndAmounts = _foodManagerCache.GetIngredientNameAndAmount(_selectedRecipeId);
            _extendedRecipe = _foodManagerCache.GetIngredients(_selectedRecipeId);
            DisplayRecipeDetails();
        }

        private void PrepareFoodBtn_Click(object sender, EventArgs e)
        {

        }

        private void AvailableBtn_Click(object sender, EventArgs e)
        {
            DisplayRecipes(RecipeAvailability.Available);
        }

        private void UnavailableBtn_Click(object sender, EventArgs e)
        {
            DisplayRecipes(RecipeAvailability.Unavailable);
        }
    }
}
