using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cook_Book.Services;
using Cook_Book.Services.API_s;
using Cook_Book.UI;
using DataAccessLayer.CustomQueryResults;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Logging;
using DomainModel.Models;
using DomainModels.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Nutrition_FitnessApp.Services;

namespace Nutrition_FitnessApp.UI
{
    public partial class HealthAnalysisForm : Form
    {
        private readonly USDAApiService _usdaApiService;
        private readonly GeminiService _geminiService;
        private readonly StabilityAIService _stabilityAIService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientsRepository _ingredientRepository;

        private List<RecipeIngredient> _recipeIngredient = new();
        private List<Recipe> _recipes = new();
        private List<Ingredient> _ingredients;
        private Dictionary<int, string> _recipesToName = new();
        private Dictionary<int, string> _ingredientsToName = new();

        public HealthAnalysisForm(IServiceProvider serviceProvider, IRecipeIngredientRepository recipeIngredientRepository, IRecipeRepository recipeRepository, IIngredientsRepository ingredientsRepository)
        {
            InitializeComponent();

            ApplyStyles(ThemeChanger.Instance.CurrentTheme);
            this.DoubleBuffered = true; 

            // making the constructor parameters more cleaner
            _serviceProvider = serviceProvider;

            _usdaApiService = _serviceProvider.GetRequiredService<USDAApiService>();
            _geminiService = _serviceProvider.GetRequiredService<GeminiService>();
            _stabilityAIService = _serviceProvider.GetRequiredService<StabilityAIService>();

            _recipeIngredientRepository = recipeIngredientRepository;
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientsRepository;
            NutritionProgressBar.Visible = false;

            _geminiService.GeminiError += errMessage => MessageBox.Show(errMessage, "Gemini Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _stabilityAIService.ErrorOccurred += errMessage => MessageBox.Show(errMessage, "StabilityAI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CustomizeGridAppearance(int? theme = 1)
        {
            NutritionGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            NutritionGrid.RowHeadersVisible = false;
            NutritionGrid.AutoGenerateColumns = false;

            JObject themeConfig = themeConfigManager.LoadThemeConfig(theme);

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

        private void CustomizeGridAppearance2(int? theme2 = 1)
        {
            IngredientsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            IngredientsGrid.AutoGenerateColumns = false;

            JObject themeConfig = themeConfigManager.LoadThemeConfig(theme2);

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

        private void GenerateAdviceBtn_Click(object sender, EventArgs e)
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

                if (totalCal == 0 && totalFat == 0 && totalProtein == 0 && totalCarbs == 0)
                {
                    MessageBox.Show("Please populate the grid first.", "Warning:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Used the short way in case their were other DI services to be added. Makes code more cleaner

                UserProfileForm form = ActivatorUtilities.CreateInstance<UserProfileForm>(_serviceProvider, totalCal, totalCarbs, totalFat, totalProtein);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLogger("Error after clicking GenerateAdviceBtn. " + ex.Message);
                MessageBox.Show("Error occurred while generating advice from Gemini.", "Advice Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GenerateAdviceBtn.Enabled = true;
                Cursor = Cursors.Default;
                GenerateAdviceBtn.Text = "Generate Advice";
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
            string disabledTertiaryBtnBgr = themeConfig["disabledTertiaryBtnBgr"]?.ToString() ?? "#d6c0ad";

            // buttons Fgr color
            string primaryBtnFgr = themeConfig["primaryBtnFgr"]?.ToString() ?? "#FFFFFF";
            string secondaryBtnFgr = themeConfig["secondaryBtnFgr"]?.ToString() ?? "#FFFFFF";
            string tertiaryBtnFgr = themeConfig["tertiaryBtnFgr"]?.ToString() ?? "#FFFFFF";
            string inputBgr = themeConfig["inputBgr"]?.ToString() ?? "#2b3b53";

            groupBox1.BackColor = ColorTranslator.FromHtml(primaryBgr);
            groupBox1.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            groupBox2.BackColor = ColorTranslator.FromHtml(primaryBgr);
            groupBox2.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            AIAdviceTab.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            ProjectionTab.BackColor = ColorTranslator.FromHtml(primaryBgr);
            AdviceTxt.BackColor = ColorTranslator.FromHtml(primaryBgr);

            ThemedTabControl.GlobalActiveBackColor = ColorTranslator.FromHtml(secondaryBgr);
            ThemedTabControl.GlobalInactiveBackColor = ColorTranslator.FromHtml(primaryBgr);
            ThemedTabControl.GlobalActiveForeColor = ColorTranslator.FromHtml(secondaryBtnFgr);
            ThemedTabControl.GlobalInactiveForeColor = ColorTranslator.FromHtml(secondaryBtnFgr);
            ThemedTabControl.GlobalPageBackColor = ColorTranslator.FromHtml(primaryBgr);
            ThemedTabControl.GlobalBorderColor = ColorTranslator.FromHtml(primaryBtnFgr);

            FetchNutritionInfoBtn.BackColor = ColorTranslator.FromHtml(secondaryBtnBgr);
            FetchNutritionInfoBtn.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);

            GenerateAdviceBtn.BackColor = ColorTranslator.FromHtml(primaryBtnBgr);
            GenerateAdviceBtn.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            GenerateProjectionBtn.BackColor = ColorTranslator.FromHtml(primaryBtnBgr);
            GenerateProjectionBtn.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            label1.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            label2.ForeColor = ColorTranslator.FromHtml(primaryFgr);

            label3.ForeColor = ColorTranslator.FromHtml (primaryFgr);
            label4.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            label7.ForeColor = ColorTranslator.FromHtml (primaryFgr);
            label8.ForeColor =ColorTranslator.FromHtml (primaryFgr);

            if(theme != 1)
            {
                TotalCaloriesLbl.ForeColor = ColorTranslator.FromHtml("#e88f41");
                TotalCarbsLbl.ForeColor = ColorTranslator.FromHtml("#e88f41");
                TotalProteinLbl.ForeColor = ColorTranslator.FromHtml("#e88f41");
                TotalFatLbl.ForeColor = ColorTranslator.FromHtml("#e88f41");
            }

            NutritionGrid.BackgroundColor = ColorTranslator.FromHtml(primaryBgr);
            IngredientsGrid.BackgroundColor = ColorTranslator.FromHtml(primaryBgr);
            NutritionGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            IngredientsGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            NutritionGrid.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            IngredientsGrid.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(primaryFgr);

            NutritionGrid.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(primaryBgr);
            IngredientsGrid.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(primaryBgr);
            NutritionGrid.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            IngredientsGrid.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            NutritionGrid.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            IngredientsGrid.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;

            this.BackColor = ColorTranslator.FromHtml(primaryBgr);

            StyleComboBox(RecipesCbx, inputBgr, primaryBtnFgr, primaryBgr, primaryBtnFgr);
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
