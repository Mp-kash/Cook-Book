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
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace Cook_Book.UI
{
    public partial class HomeForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private DesktopFileWatcher _desktopFileWatcher;
        private ThemeChanger _themeChanger;
        public HomeForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            _desktopFileWatcher = _serviceProvider.GetRequiredService<DesktopFileWatcher>();
            _themeChanger = _serviceProvider.GetRequiredService<ThemeChanger>();

            // Using lamda expression to subsribe to the event
            _desktopFileWatcher.OnFileStatusChanged += fileExists => Invoke(() => NotificationIcon.Visible = fileExists);
            _themeChanger.OnThemeChanged += theme => Invoke(() => ApplyStyles(theme));


            NotificationIcon.Visible = DesktopFileWatcher.CurrentFileStatus;
            ApplyStyles(_themeChanger.CurrentTheme);
        }

        private void FridgeIngredientsBtn_Click(object sender, EventArgs e)
        {
            IngredientsForm form = _serviceProvider.GetRequiredService<IngredientsForm>();
            form.Text = "Fridge";
            ShowForm(form);
        }

        private void RecipesBtn_Click(object sender, EventArgs e)
        {
            RecipesForm form = _serviceProvider.GetRequiredService<RecipesForm>();
            form.Text = "Recipes";
            ShowForm(form);
        }

        private void FoodManagerBtn_Click(object sender, EventArgs e)
        {
            FoodManagerForm form = _serviceProvider.GetRequiredService<FoodManagerForm>();
            form.Text = "Food Manager";
            ShowForm(form);
        }

        private void HealthAnalysisBtn_Click(object sender, EventArgs e)
        {
            HealthAnalysisForm form = _serviceProvider.GetRequiredService<HealthAnalysisForm>();
            form.Text = "Health Analysis";
            ShowForm(form);
        }

        private void ShowForm(Form form)
        {
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void ApplyStyles(int? theme = 1)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Home";

            JObject themeConfig = themeConfigManager.LoadThemeConfig(theme);
            if (theme == 2)
            {
                FridgeIngredientsBtn.Image = Properties.Resources.icons8_fridge_32_blue;
                RecipesBtn.Image = Properties.Resources.icons8_recipe_32_blue;
                FoodManagerBtn.Image = Properties.Resources.icons8_dish_36_blue;
                HealthAnalysisBtn.Image = Properties.Resources.icons8_first_aid_32_blue;
            }
            else
            {
                FridgeIngredientsBtn.Image = Properties.Resources.icons8_fridge_32;
                RecipesBtn.Image = Properties.Resources.icons8_recipe_32;
                FoodManagerBtn.Image = Properties.Resources.icons8_dish_32;
                HealthAnalysisBtn.Image = Properties.Resources.icons8_first_aid_32;
            }


            this.BackColor = ColorTranslator.FromHtml(themeConfig?["primaryBgr"]?.ToString() ?? "#2d425b");
            this.ForeColor = ColorTranslator.FromHtml(themeConfig?["primaryFgr"]?.ToString() ?? "#ffffff");
            FridgeIngredientsBtn.BackColor = ColorTranslator.FromHtml(themeConfig?["primaryBgr"]?.ToString() ?? "#3a4b6c");
            FridgeIngredientsBtn.ForeColor = ColorTranslator.FromHtml(themeConfig?["primaryBtnFgr"]?.ToString() ?? "#ffffff");

            RecipesBtn.BackColor = ColorTranslator.FromHtml(themeConfig?["primaryBgr"]?.ToString() ?? "#3a4b6c");
            RecipesBtn.ForeColor = ColorTranslator.FromHtml(themeConfig?["primaryBtnFgr"]?.ToString() ?? "#3a4b6c");

            FoodManagerBtn.BackColor = ColorTranslator.FromHtml(themeConfig?["primaryBgr"]?.ToString() ?? "#3a4b6c");
            FoodManagerBtn.ForeColor = ColorTranslator.FromHtml(themeConfig?["primaryBtnFgr"]?.ToString() ?? "#3a4b6c");

            HealthAnalysisBtn.BackColor = ColorTranslator.FromHtml(themeConfig?["primaryBgr"]?.ToString() ?? "#3a4b6c");
            HealthAnalysisBtn.ForeColor = ColorTranslator.FromHtml(themeConfig?["primaryBtnFgr"]?.ToString() ?? "#3a4b6c");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.O))
            {
                SecretForm form = _serviceProvider.GetRequiredService<SecretForm>();
                ShowForm(form);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
      
    }
}
