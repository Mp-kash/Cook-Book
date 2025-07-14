using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.Interfaces;
using DomainModel.Models;

namespace Cook_Book.UI
{
    public partial class RecipeTypeForm : Form
    {
        private IRecipeTypeRepository _recipeTypeRepository;
        public RecipeTypeForm(IRecipeTypeRepository recipeTypeRepository)
        {
            InitializeComponent();
            _recipeTypeRepository = recipeTypeRepository;

            _recipeTypeRepository.ErrorOccurred += (errorMessage) =>
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void RecipeTypeForm_Load(object sender, EventArgs e)
        {
            RefreshRecipeTypes();
        }

        private async void RefreshRecipeTypes()
        {
            RecipeTypeLbx.DataSource = await _recipeTypeRepository.GetRecipeTypes();
            RecipeTypeLbx.DisplayMember = "Name";
        }

        private async void AddRecipeBtn_Click(object sender, EventArgs e)
        {
            string recipeType = RecipeTypeTxt.Text.Trim();

            if (!string.IsNullOrEmpty(recipeType))
            {

                RecipeType newRecipeType = new RecipeType
                {
                    Name = recipeType
                };

                await _recipeTypeRepository.InsertRecipeType(newRecipeType);
                RefreshRecipeTypes();
                RecipeTypeTxt.Text = string.Empty;
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (RecipeTypeLbx.SelectedItem == null)
            {
                MessageBox.Show("Please select a recipe type to remove.", "No Selection");
                return;
            }

            RecipeType selectedRecipeType = (RecipeType)RecipeTypeLbx.SelectedItem;

            DialogResult result = MessageBox.Show($"Are you sure you want to remove '{selectedRecipeType.Name}'?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _recipeTypeRepository.DeleteRecipeType(selectedRecipeType);
                RefreshRecipeTypes();
            }
        }
    }
}
