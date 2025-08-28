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
using DataAccessLayer.Logging;

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

        private decimal _totalCal;
        private decimal _totalCarbs;
        private decimal _totalFats;
        private decimal _totalProteins;
        
        public UserProfileForm(GeminiService geminiService, decimal totalCal, decimal totalCarbs, decimal totalFats, decimal totalProteins)
        {
            InitializeComponent();
            _geminiService = geminiService;

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

        private bool ValidateInputs()
        {
            if (AgeNumeric.Value == 0 || AgeNumeric.Value > 100)
            {
                MessageBox.Show($"{AgeNumeric.Value} yrs is not a reasonable age.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AgeNumeric.Focus();
                return false;
            }
            if (WeightNumeric.Value == 0 || WeightNumeric.Value > 635)
            {
                MessageBox.Show($"{WeightNumeric.Value} kg is not a reasonable weight.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                WeightNumeric.Focus();
                return false;
            }
            if (HeightNumeric.Value == 0 || HeightNumeric.Value > 251)
            {
                MessageBox.Show($"{HeightNumeric} cm is not a reasonable height.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HeightNumeric.Focus();
                return false;
            }
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
            if (string.IsNullOrWhiteSpace(AgeNumeric.Text))
            {
                MessageBox.Show("Please enter your gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GenderTxt.Focus();
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

                string prompt = GeneratePersonalizedPrompt(); 
                
                string advice = await _geminiService.GetNutritionAdviceAsync(prompt);

                GeminiForm form = new GeminiForm(advice);
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

                Make the advice specific, actionable, concise and scientifically sound.";
        }
    }
}
