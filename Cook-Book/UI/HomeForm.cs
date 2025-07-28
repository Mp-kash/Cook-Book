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

namespace Cook_Book.UI
{
    public partial class HomeForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private DesktopFileWatcher _desktopFileWatcher;
        public HomeForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            _desktopFileWatcher = _serviceProvider.GetRequiredService<DesktopFileWatcher>();

            // Using lamda expression to subsribe to the event
            _desktopFileWatcher.OnFileStatusChanged += fileExists => Invoke(() => NotificationIcon.Visible = fileExists);

            this.StartPosition = FormStartPosition.CenterScreen;

            NotificationIcon.Visible = DesktopFileWatcher.CurrentFileStatus;
        }

        private void FridgeIngredientsBtn_Click(object sender, EventArgs e)
        {
            IngredientsForm form = _serviceProvider.GetRequiredService<IngredientsForm>();
            ShowForm(form);
        }

        private void RecipesBtn_Click(object sender, EventArgs e)
        {
            RecipesForm form = _serviceProvider.GetRequiredService<RecipesForm>();
            ShowForm(form);
        }

        private void FoodManagerBtn_Click(object sender, EventArgs e)
        {
            FoodManagerForm form = _serviceProvider.GetRequiredService<FoodManagerForm>();
            ShowForm(form);
        }

        private void ShowForm(Form form)
        {
            form.MaximizeBox = false;
            form.MinimizeBox = true;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Control | Keys.O))
            {
                SecretForm form = _serviceProvider.GetRequiredService<SecretForm>();
                ShowForm(form);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
