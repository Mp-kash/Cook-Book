using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cook_Book.Services.API_s;
using DataAccessLayer.CustomQueryResults;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Logging;
using DomainModel.Models;
using DomainModels.Models;

namespace Cook_Book
{
    public partial class HealthAnalysisForm : Form
    {
        private readonly USDAApiService _usdaApiService;
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientsRepository _ingredientRepository;

        private List<RecipeIngredient> _recipeIngredient = new();
        private List<Recipe> _recipes = new();
        private List<Ingredient> _ingredients;
        private Dictionary<int, string> _recipesToName = new();
        private Dictionary<int, string> _ingredientsToName = new();

        public HealthAnalysisForm(USDAApiService usdaApiService, IRecipeIngredientRepository recipeIngredientRepository, IRecipeRepository recipeRepository, IIngredientsRepository ingredientsRepository)
        {
            InitializeComponent();

            _usdaApiService = usdaApiService;
            _recipeIngredientRepository = recipeIngredientRepository;
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientsRepository;
        }

        private void ErrorLogger(string exMessage)
        {
            Logger.Log(exMessage, DateTime.Now);
        }
        private async void HealthAnalysisForm_Load(object sender, EventArgs e)
        {
            _recipeIngredient = await _recipeIngredientRepository.GetAllRecipeIngredients();
            _recipes = await _recipeRepository.GetAllRecipes();
            _ingredients = await _ingredientRepository.GetIngredients();

            _recipesToName = _recipes.ToDictionary(r => r.Id, r => r.Name);
            _ingredientsToName = _ingredients.ToDictionary(i => i.Id, i => i.Name);
            LoadRecipesCbx();
            CustomizeGridAppearance();
        }

        private void CustomizeGridAppearance()
        {
            IngredientsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            IngredientsGrid.RowHeadersVisible = false;
            IngredientsGrid.AutoGenerateColumns = false;

            DataGridViewColumn[] column = new DataGridViewColumn[4];
            column[0] = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ingredient",
                DataPropertyName = "Ingredient"
            };
            column[1] = new DataGridViewTextBoxColumn
            {
                HeaderText = "Calories (kcal)",
                DataPropertyName = "Calories"
            };
            column[2] = new DataGridViewTextBoxColumn
            {
                HeaderText = "Carbs (g)",
                DataPropertyName = "Carbs"
            };
            column[3] = new DataGridViewTextBoxColumn
            {
                HeaderText = "Fat (g)",
                DataPropertyName = "Fat"
            };

            IngredientsGrid.Columns.Clear();
            IngredientsGrid.Columns.AddRange(column);
        }

        private async void FetchNutritionInfoBtn_Click(object sender, EventArgs e)
        {
            if (RecipesCbx.SelectedIndex <= 0 || RecipesCbx.SelectedItem == null)
            {
                MessageBox.Show("Please select a recipe first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string? selectedRecipeName = RecipesCbx.SelectedItem.ToString();
            int selectedRecipeId = _recipesToName.FirstOrDefault(x => x.Value == selectedRecipeName).Key;

            var selectedIngredients = _recipeIngredient
                .Where(ri => ri.RecipeId == selectedRecipeId)
                .Select(ri => new
                {
                    IngredientId = ri.IngredientId,
                    Amount = ri.Amount
                })    
                .ToList();

            List<IngredientNutritionInfo> nutritionList = new();

            FetchNutritionInfoBtn.Enabled = false;
            FetchNutritionInfoBtn.Text = "Fetching...";

            try
            {
                foreach (var item in selectedIngredients)
                {
                    if (!_ingredientsToName.TryGetValue(item.IngredientId, out string ingredientName))
                        continue;

                    // get nutrition info from USDA API
                    var nutritionInfo = await _usdaApiService.GetIngredientNutriationAsync(ingredientName);

                    if (nutritionInfo != null)
                    {
                        nutritionInfo.Calories = Math.Round((nutritionInfo.Calories * item.Amount) / 100, 2);
                        nutritionInfo.Carbs = Math.Round((nutritionInfo.Carbs * item.Amount) / 100, 2);
                        nutritionInfo.Fat = Math.Round((nutritionInfo.Fat * item.Amount) / 100, 2);

                        nutritionList.Add(nutritionInfo);
                    }
                    else
                    {
                        nutritionList.Add(new IngredientNutritionInfo
                        {
                            Ingredient = ingredientName,
                            Calories = 0,
                            Carbs = 0,
                            Fat = 0,
                            Protein = 0
                        });
                    }
                }
                // update the grid
                IngredientsGrid.DataSource = null;
                IngredientsGrid.DataSource = nutritionList;
            } catch(Exception ex)
            {
                MessageBox.Show("Error occurred while fetching Nutritional Data from the API!", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLogger("Error occurred while fetching Nutritional Data from the API: " + ex.Message);
            }
            finally
            {
                FetchNutritionInfoBtn.Enabled = true;
                FetchNutritionInfoBtn.Text = "Fetch Nutrition Info";
            }
        }

        private void LoadRecipesCbx()
        {
            IEnumerable<int> recipeIds = _recipeIngredient.Select(ri => ri.RecipeId).Distinct();  // removes duplicate

            List<string> recipeNames = new List<string> { "Select a recipe" };

            recipeNames.AddRange(
                recipeIds.Select(id => _recipesToName.TryGetValue(id, out string name) ? name : "unknown").ToList()
            );

            List<int> ids = new List<int> { 0 };

            ids.AddRange(recipeIds);

            RecipesCbx.DataSource = recipeNames;
            RecipesCbx.SelectedIndex = 0;
        }

        private void RecipesCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RecipesCbx.SelectedIndex <= 0 || RecipesCbx.SelectedItem == null)
            {
                IngredientsGrid.DataSource = null;
                return;
            }

            string? selectedRecipeName = RecipesCbx.SelectedItem.ToString();

            int selectedRecipeId = _recipesToName.FirstOrDefault(x => x.Value == selectedRecipeName).Key;

            var selectedIngredients = _recipeIngredient
                .Where(ri => ri.RecipeId == selectedRecipeId)
                .Select(ri =>
                {
                    Ingredient? ingredient = _ingredients.FirstOrDefault(x => x.Id == ri.IngredientId);
                    _ingredientsToName.TryGetValue(ri.IngredientId, out string name);
                    decimal calories = (ingredient.KcalPer100g * ri.Amount) / 100;
                    return new
                    {
                        Ingredient = name,
                        Calories = Math.Round(calories, 2),
                        Carbs = 0,
                        Fat = 0
                    };
                })
                .ToList();

            IngredientsGrid.DataSource = selectedIngredients;
        }  
    }
}
