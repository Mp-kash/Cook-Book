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
using DataAccessLayer.Logging;
using Newtonsoft.Json.Linq;

namespace Cook_Book.UI
{
    public partial class UserProfileForm : Form
    {
        public string GenderInput { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal Age { get; set; }
        public string Goal { get; set; }
        public string ActivityLevel { get; set; }

        private readonly GeminiService _geminiService;
        private readonly StabilityAIService _stabilityAIService;

        private decimal _totalCal;
        private decimal _totalCarbs;
        private decimal _totalFats;
        private decimal _totalProteins;

        private string _successImage;
        private string _failureImage;
        
        public UserProfileForm(GeminiService geminiService, StabilityAIService stabilityAIService, decimal totalCal, decimal totalCarbs, decimal totalFats, decimal totalProteins)
        {
            InitializeComponent();

            ShowForm();
            ApplyStyles(ThemeChanger.Instance.CurrentTheme);

            _geminiService = geminiService;
            _stabilityAIService = stabilityAIService;

            _totalCal = totalCal;
            _totalCarbs = totalCarbs;
            _totalFats = totalFats;
            _totalProteins = totalProteins;
        }

        private void UserProfileForm_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            LoadInputs();           
        }

        private async Task GenerateTrasnformationVisualization()
        {
            try
            {
                var successTask = _stabilityAIService.GenerateBodyTransformationImage((int)Age, GenderInput, Goal, "success");

                var failureTask = _stabilityAIService.GenerateBodyTransformationImage((int)Age, GenderInput, Goal, "failure");

                await Task.WhenAll(successTask, failureTask);

                _successImage = await successTask;
                _failureImage = await failureTask;

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log(ex.Message, DateTime.Now);
            }
        }


        private bool ValidateInputs()
        {
            if (GoalCbx.SelectedIndex == 0)
            {
                MessageBox.Show("Invalid fitness goal!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GoalCbx.Focus();
                return false;
            }
            if (ActivityCbx.SelectedIndex == 0)
            {
                MessageBox.Show("Invalid activity level!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActivityCbx.Focus();
                return false;
            }
            if (AgeNumeric.Value == 0 || AgeNumeric.Value > 100)
            {
                MessageBox.Show($"{AgeNumeric.Value} yrs is not a reasonable age.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AgeNumeric.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(GenderTxt.Text))
            {
                MessageBox.Show("Please enter your gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GenderTxt.Focus();
                return false;
            }           
            if (HeightNumeric.Value == 0 || HeightNumeric.Value > 251)
            {
                MessageBox.Show($"{HeightNumeric} cm is not a reasonable height.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HeightNumeric.Focus();
                return false;
            }          
            if (WeightNumeric.Value == 0 || WeightNumeric.Value > 635)
            {
                MessageBox.Show($"{WeightNumeric.Value} kg is not a reasonable weight.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                WeightNumeric.Focus();
                return false;
            }            

            return true;
        }

        private void LoadInputs()
        {
            GenderInput = GenderTxt.Text.Trim();
            Age = AgeNumeric.Value;
            Weight = WeightNumeric.Value;
            Height = HeightNumeric.Value;
            Goal = GoalCbx.SelectedItem.ToString();
            ActivityLevel = ActivityCbx.SelectedItem.ToString();
        }

        private void LoadCombobox()
        {
            GoalCbx.Items.Clear();
            ActivityCbx.Items.Clear();

            GoalCbx.Items.Add("Select a Goal");
            GoalCbx.Items.Add("Weight Loss");
            GoalCbx.Items.Add("Maintenance");
            GoalCbx.Items.Add("Muscle Gain");

            ActivityCbx.Items.Add("Select Activity Level");
            ActivityCbx.Items.Add("Sedentary (little to no exercise)");
            ActivityCbx.Items.Add("Lightly Active (light exercise 1-3 days/week)");
            ActivityCbx.Items.Add("Moderately Active (moderate exercise 3-5 days/week)");
            ActivityCbx.Items.Add("Very Active (hard exercise 6-7 days/week)");
            ActivityCbx.Items.Add("Extremely Active (very hard exercise, physical job)");

            GoalCbx.SelectedIndex = 0;
            ActivityCbx.SelectedIndex = 0;
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs()) return;

                LoadInputs();

                SubmitButton.Enabled = false;
                SubmitButton.Text = "Submitting...";
                Cursor = Cursors.WaitCursor;

                string prompt = GeneratePersonalizedPrompt(); 
                
                string advice = await _geminiService.GetNutritionAdviceAsync(prompt);

                await GenerateTrasnformationVisualization();

                GeminiForm form = new GeminiForm(advice, _successImage, _failureImage);
                form.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating advice from Gemini.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log(ex.Message, DateTime.Now);
            }
            finally
            {
                SubmitButton.Enabled = true;
                SubmitButton.Text = "Submit";
                Cursor= Cursors.Default;
            }
        }

        private string GeneratePersonalizedPrompt()
        {
            return $@"Create a personalized nutrition and fitness plan for:

                USER PROFILE:
                - Age: {Age} years
                - Gender: {GenderInput}
                - Weight: {Weight} kg
                - Height: {Height} cm
                - Goal: {Goal}
                - Activity Level: {ActivityLevel}

                Meal nutrition:
                    - Calories: {_totalCal}
                    - Carbs: {_totalCarbs}
                    - Fat: {_totalFats}
                    - Protein: {_totalProteins}
                NB: These is a meal for one diet eaten during the day.

                Please provide:
                1. Daily calorie target recommendation
                2. Macronutrient breakdown (protein/carbs/fat)
                3. Meal timing suggestions
                4. Recommended foods and supplements
                5. Exercise recommendations
                6. Weekly progress tracking tips

                Make the advice specific, actionable, concise and scientifically sound.
                NB: Max Output Token < 650.";
        }

        private void ShowForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "User Profile";
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

            label1.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            label2.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            label3.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            label4.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            label5.ForeColor = ColorTranslator.FromHtml(primaryFgr);

            AgeNumeric.BackColor = ColorTranslator.FromHtml(inputBgr);
            AgeNumeric.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);

            GenderTxt.BackColor = ColorTranslator.FromHtml(inputBgr);
            GenderTxt.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);

            HeightNumeric.BackColor = ColorTranslator.FromHtml(inputBgr);
            HeightNumeric.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);

            WeightNumeric.BackColor = ColorTranslator.FromHtml(inputBgr);
            WeightNumeric.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);

            SubmitButton.BackColor = ColorTranslator.FromHtml(tertiaryBtnBgr);
            SubmitButton.ForeColor = ColorTranslator.FromHtml(tertiaryBtnFgr);

            this.BackColor = ColorTranslator.FromHtml(primaryBgr);

            StyleComboBox(GoalCbx, inputBgr, primaryBtnFgr, primaryBgr, primaryBtnFgr);
            StyleComboBox(ActivityCbx, inputBgr, primaryBtnFgr, primaryBgr, primaryBtnFgr);
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
