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

        //private List<RecipesWithTypes> _recipesWithTypes = new();
        private List<RecipeIngredientWithNameAndAmount> _recipeIngredientWithNameAndAmounts = new();

        public int selectedRecipeId { get; set; }
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
            DisplayRecipes(RecipeAvailability.Available);
            GetRecipeId();
            await _foodManagerCache.RefreshData();
            DisplayNameAndAmount();
        }

        private void DisplayRecipes(RecipeAvailability recipeAvailability)
        {
            List<Recipe> dataSource = new List<Recipe>();
            RecipesLbx.DataSource = null;
            if (recipeAvailability == RecipeAvailability.Available)
                RecipesLbx.DataSource = _foodManagerCache.AvailableRecipes;
            else if (recipeAvailability == RecipeAvailability.Unavailable)
                RecipesLbx.DataSource = _foodManagerCache.UnavilableRecipes;

            RecipesLbx.DisplayMember = "Name";
            RecipesLbx.ValueMember = "Id";
            //RecipesLbx.SelectedIndex = 0;
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

        }

        private void GetRecipeId()
        {
            if (RecipesLbx.SelectedItem == null)
            {
                selectedRecipeId = 0;
                return;
            }
            Recipe selectedRecipe = (Recipe)RecipesLbx.SelectedItem;
            selectedRecipeId = selectedRecipe.Id;
        }

        private async void RecipesLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRecipeId(); // update the _selectedRecipeId
            _recipeIngredientWithNameAndAmounts = await _recipeIngredientRepository.GetRecipeIngredients(selectedRecipeId);
            DisplayNameAndAmount();
            //OnSelectedItemChanged();
        }

        private void OnSelectedItemChanged()
        {
            throw new NotImplementedException();

        }

        private void DisplayNameAndAmount()
        {
            if (RecipesLbx.SelectedItem == null)
            {
                IngredientsLbx.DataSource = new List<Recipe>();
                return;
            }

            List<RecipeIngredientsVM> recipeIngredientsVMs = _recipeIngredientWithNameAndAmounts
                .Select(ri => new RecipeIngredientsVM(ri.Name, ri.IngredientId, ri.Amount))
                .ToList();

            IngredientsLbx.DataSource = null;
            IngredientsLbx.DataSource = recipeIngredientsVMs;
            IngredientsLbx.DisplayMember = "NameWithAmount";
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
