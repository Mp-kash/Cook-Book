using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cook_Book.ViewModel;
using DataAccessLayer.CustomQueryResults;
using DataAccessLayer.Interfaces;
using DomainModel.Models;
using DomainModels.Models;

namespace Cook_Book.UI
{
    public partial class RecipeIngredientsForm : Form
    {
        private IIngredientsRepository _ingredientsRepository;
        private IRecipeIngredientRepository _recipeIngredientRepository;

        List<RecipeIngredientsVM> _recipeIngredientsVMs = new();

        // Public property to set recipe name and update label
        public string RecipeName
        {
            set
            {
                RecipeTypeLbl.Text = $"Ingredient(s) for:\n{value}";
            }
        }
        public int RecipeId { get; set; }

        public RecipeIngredientsForm(IIngredientsRepository ingredientsRepository, IRecipeIngredientRepository recipeIngredientRepository)
        {
            InitializeComponent();
            _ingredientsRepository = ingredientsRepository;
            _recipeIngredientRepository = recipeIngredientRepository;

            // Subscribed to the ErrorOccurred event to handle errors
            _recipeIngredientRepository.ErrorOccurred += (errorMessage) =>
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private async void RecipeIngredientsForm_Load(object sender, EventArgs e)
        {
            await LoadIngredientsInListBox();
            RefreshNameAndAmount();
        }

        private async Task LoadIngredientsInListBox()
        {
            AllIngredientsLbx.DataSource = await _ingredientsRepository.GetIngredients();
            AllIngredientsLbx.DisplayMember = "Name";
        }

        private async void RefreshNameAndAmount()
        {
            _recipeIngredientsVMs.Clear(); // Clear the existing list to avoid duplicates
            List<RecipeIngredientWithNameAndAmount> recipeIngredients = await _recipeIngredientRepository.GetRecipeIngredients(RecipeId);           

            recipeIngredients.ForEach(ri =>
            {
                _recipeIngredientsVMs.Add(new RecipeIngredientsVM(ri.Name, ri.IngredientId, ri.Amount));
            });

            // Refresh the list box with the new ingredient
            RecipeIngredientsLbx.DataSource = null;
            RecipeIngredientsLbx.DataSource = _recipeIngredientsVMs;
            RecipeIngredientsLbx.DisplayMember = "NameWithAmount";
        }

        private void AddIngredientsBtn_Click(object sender, EventArgs e)
        {
            // Get selected ingredient
            Ingredient selectedIngredient = AllIngredientsLbx.SelectedItem as Ingredient;
            if (selectedIngredient == null)
            {
                MessageBox.Show("Please select an ingredient to add.", "No Ingredient Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (AmountsForm amountForm = new AmountsForm())
            {
                if (amountForm.ShowDialog() == DialogResult.OK)
                {
                    RecipeIngredient recipeIngredient = new RecipeIngredient(RecipeId, selectedIngredient.Id, amountForm.Amount);

                    CheckIfRecipeIngredient(recipeIngredient);
                    RefreshNameAndAmount();
                }
            }
        }

        private async void CheckIfRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            if(_recipeIngredientsVMs.Any(ri => ri.IngredientId == recipeIngredient.IngredientId))
            {
                // Update if it already exists
                await _recipeIngredientRepository.UpdateRecipeIngredient(recipeIngredient);
            }
            else
            {
                // Insert if it does not exist
                await _recipeIngredientRepository.InsertRecipeIngredint(recipeIngredient);
            }
        }

        private async void RemoveIngredientBtn_Click(object sender, EventArgs e)
        {
            RecipeIngredientsVM selectedRecipeIngredient = RecipeIngredientsLbx.SelectedItem as RecipeIngredientsVM;

            if (selectedRecipeIngredient == null)
            {
                MessageBox.Show("Please select an ingredient to remove.", "No Ingredient Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show($"Are you sure you want to remove '{selectedRecipeIngredient.Name}' from the recipe?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Remove the ingredient from the recipe
                await _recipeIngredientRepository.DeleteRecipeIngredient(RecipeId, selectedRecipeIngredient.IngredientId);
                RefreshNameAndAmount();
            }
        }
    }
}
