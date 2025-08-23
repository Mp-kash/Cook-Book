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
using Newtonsoft.Json.Linq;

namespace Cook_Book
{
    public partial class HealthAnalysisForm : Form
    {
        private readonly USDAApiService _usdaApiService;
        private readonly GeminiService _geminiService;
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientsRepository _ingredientRepository;

        private List<RecipeIngredient> _recipeIngredient = new();
        private List<Recipe> _recipes = new();
        private List<Ingredient> _ingredients;
        private Dictionary<int, string> _recipesToName = new();
        private Dictionary<int, string> _ingredientsToName = new();

        public HealthAnalysisForm(USDAApiService usdaApiService, IRecipeIngredientRepository recipeIngredientRepository, IRecipeRepository recipeRepository, IIngredientsRepository ingredientsRepository, GeminiService geminiService)
        {
            InitializeComponent();

            _usdaApiService = usdaApiService;
            _recipeIngredientRepository = recipeIngredientRepository;
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientsRepository;
            NutritionProgressBar.Visible = false;
            _geminiService = geminiService;
            _geminiService.GeminiError += errMessage => MessageBox.Show(errMessage, "Gemini Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            CustomizeGridAppearance2();
        }

        private void CustomizeGridAppearance()
        {
            NutritionGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            NutritionGrid.RowHeadersVisible = false;
            NutritionGrid.AutoGenerateColumns = false;

            DataGridViewColumn[] column = new DataGridViewColumn[5];
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
            column[4] = new DataGridViewTextBoxColumn
            {
                HeaderText = "Protein (g)",
                DataPropertyName = "Protein"
            };
            NutritionGrid.Columns.Clear();
            NutritionGrid.Columns.AddRange(column);
        }

        private void CustomizeGridAppearance2()
        {
            IngredientsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            IngredientsGrid.AutoGenerateColumns = false;

            DataGridViewColumn[] column = new DataGridViewColumn[4];
            column[0] = new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "Ingredient" };
            column[1] = new DataGridViewTextBoxColumn() { DataPropertyName = "Amount", HeaderText = "Amount" };
            column[2] = new DataGridViewTextBoxColumn() { DataPropertyName = "KcalPer100g", HeaderText = "Cal (100g)" };
            column[3] = new DataGridViewTextBoxColumn() { DataPropertyName = "PricePer100g", HeaderText = "Price (100g)" };

            IngredientsGrid.RowHeadersVisible = false;
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
            Cursor = Cursors.WaitCursor;
            NutritionProgressBar.Visible = true;
            NutritionProgressBar.Style = ProgressBarStyle.Marquee;

            try
            {

                var nutritionTasks = new List<Task<IngredientNutritionInfo>>(); // List to hold tasks.

                foreach (var item in selectedIngredients)
                {
                    if (!_ingredientsToName.TryGetValue(item.IngredientId, out string ingredientName))
                        continue;

                    nutritionTasks.Add(GetNutritionWithAmountAsync(ingredientName, item.Amount));
                }

                var nutritionResults = await Task.WhenAll(nutritionTasks);

                decimal totalCal = nutritionResults.Sum(x => x.Calories);
                decimal totalCarbs = nutritionResults.Sum(x => x.Carbs);
                decimal totalFat = nutritionResults.Sum(x => x.Fat);
                decimal totalProtein = nutritionResults.Sum(x => x.Protein);

                TotalCaloriesLbl.Text = totalCal.ToString();
                TotalCarbsLbl.Text = totalCarbs.ToString();
                TotalFatLbl.Text = totalFat.ToString();
                TotalProteinLbl.Text = totalProtein.ToString();

                NutritionGrid.DataSource = null;
                NutritionGrid.DataSource = nutritionResults.Where(r => r != null).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while fetching Nutritional Data from the API!", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLogger("Error occurred while fetching Nutritional Data from the API: " + ex.Message);
            }
            finally
            {
                NutritionProgressBar.Visible = false;
                FetchNutritionInfoBtn.Enabled = true;
                FetchNutritionInfoBtn.Text = "Fetch Nutrition Info";
                Cursor = Cursors.Default;
            }
        }

        private async Task<IngredientNutritionInfo> GetNutritionWithAmountAsync(string ingredientName, decimal amount)
        {
            // get nutrition info from USDA API
            var nutritionInfo = await _usdaApiService.GetIngredientNutriationAsync(ingredientName);
            if (nutritionInfo == null) return null;

            decimal amountFactor = amount / 100m;
            return new IngredientNutritionInfo
            {
                Ingredient = ingredientName,
                Calories = Math.Round(nutritionInfo.Calories * amountFactor, 2),
                Carbs = Math.Round(nutritionInfo.Carbs * amountFactor, 2),
                Fat = Math.Round(nutritionInfo.Fat * amountFactor, 2),
                Protein = Math.Round(nutritionInfo.Protein * amountFactor, 2)
            };
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
                NutritionGrid.DataSource = null;
                return;
            }

            TotalCaloriesLbl.Text = "0.00";
            TotalCarbsLbl.Text = "0.00";
            TotalFatLbl.Text = "0.00";
            TotalProteinLbl.Text = "0.00";

            string? selectedRecipeName = RecipesCbx.SelectedItem.ToString();

            int selectedRecipeId = _recipesToName.FirstOrDefault(x => x.Value == selectedRecipeName).Key;

            var selectedIngredients = _recipeIngredient
                .Where(ri => ri.RecipeId == selectedRecipeId)
                .Select(ri =>
                {
                    Ingredient? ingredient = _ingredients.FirstOrDefault(x => x.Id == ri.IngredientId);
                    _ingredientsToName.TryGetValue(ri.IngredientId, out string name);

                    return new
                    {
                        Name = name,
                        Amount = Math.Round(ri.Amount, 2),
                        KcalPer100g = Math.Round((ingredient?.KcalPer100g ?? 0) * ri.Amount / 100, 2),
                        PricePer100g = Math.Round((ingredient?.PricePer100g ?? 0) * ri.Amount / 100, 2)
                    };
                })
                .ToList();

            IngredientsGrid.DataSource = selectedIngredients;

            NutritionGrid.DataSource = selectedIngredients.Select(x => new
            {
                Ingredient = x.Name,
                Calories = 0,
                Carbs = 0,
                Fat = 0,
                Protein = 0
            }).ToList();
        }

        private async void GenerateAdviceBtn_Click(object sender, EventArgs e)
        {
            if (RecipesCbx.SelectedIndex <= 0 || RecipesCbx.SelectedItem == null)
            {
                MessageBox.Show("Please select a recipe first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                GenerateAdviceBtn.Enabled = false;
                Cursor = Cursors.WaitCursor;
                GenerateAdviceBtn.Text = "Generating...";

                decimal totalCal = decimal.Parse(TotalCaloriesLbl.Text);
                decimal totalFat = decimal.Parse(TotalFatLbl.Text);
                decimal totalProtein = decimal.Parse(TotalProteinLbl.Text);
                decimal totalCarbs = decimal.Parse(TotalCarbsLbl.Text);

                if(totalCal == 0 && totalFat == 0 && totalProtein == 0 && totalCarbs == 0)
                {
                    MessageBox.Show("Please populate the grid first.", "Warning:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string prompt = BuildNutritionPrompt(totalCal, totalFat, totalProtein, totalCarbs);

                var advice = await _geminiService.GetNutritionAdviceAsync(prompt);

                AdviceTxt.Text = advice;

            }
            catch (Exception ex)
            {
                ErrorLogger("Error after clicking GenerateAdviceBtn. "+ex.Message);
                MessageBox.Show("Error occurred while generating advice from Gemini.", "Advice Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GenerateAdviceBtn.Enabled = true;
                Cursor = Cursors.Default;
                GenerateAdviceBtn.Text = "Generate Advice";
            }
        }

        private string BuildNutritionPrompt(decimal totalCal, decimal totalFat, decimal totalProtein, decimal totalCarbs)
        {
            return $@"User profile:
                    - Male, 20 years, 165 cm, 84 kg
                    - Activity: Moderate
                    - Goal: Weight loss

                    1 Meal nutrition:
                    - Calories: {totalCal}
                    - Carbs: {totalCarbs}
                    - Fat: {totalFat}
                    - Protein: {totalProtein}

                    Give friendly nutrition advice and recommendation tailored to this person.
                    NB:   Make the message readable by adding spaces and starting sentences on a new line.";

        }
    }
}
