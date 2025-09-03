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

namespace Nutrition_FitnessApp.UI
{
    public partial class SecretForm : Form
    {
        public SecretForm()
        {
            InitializeComponent();
            PreparedFoodCounter.Text = $"Prepared Recipes: {DesktopFileWatcher.Instance.PreparedRecipesCounter.ToString()}";
        }
    }
}
