using System.Diagnostics;
using System.DirectoryServices;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DomainModels.Models;

namespace Cook_Book.UI
{
    public partial class IngredientsForm : Form
    {
        readonly IIngredientsRepository _ingredientsRepository;

        // This will cache the Ingredients from the db to avoid unncessary requests
        private List<Ingredient> _ingredients = new();
        private List<Ingredient> _matchingIngredients = new();
        private string _currentSort = "None";

        public IngredientsForm(IIngredientsRepository ingredientsRepository)
        {
            InitializeComponent();

            _ingredientsRepository = ingredientsRepository;
        }

        private async void IngredientsForm_Load(object sender, EventArgs e)
        {
            _ingredients = await _ingredientsRepository.GetIngredients();
            SortByComboBox();
            SearchAndRefreshResult();
            CustomizeGridAppearance();
        }

        private async void AddIngredientBtn_Click(object sender, EventArgs e)
        {
            if (!isValid())
                return;

            Ingredient ingredients = new Ingredient(NameTxt.Text, TypeTxt.Text, WeightNum.Value, KcalPer100gNum.Value, PricePer100gNum.Value);

            AddIngredientBtn.Enabled = false;
            await _ingredientsRepository.InsertIngredients(ingredients);
            AddIngredientBtn.Enabled = true;

            // Update the cached ingredient
            _ingredients = await _ingredientsRepository.GetIngredients();

            SearchAndRefreshResult();
            ClearInputFields();
        }

        private void CustomizeGridAppearance()
        {
            IngredientsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            IngredientsDataGrid.AutoGenerateColumns = false;

            DataGridViewColumn[] column = new DataGridViewColumn[6];
            column[0] = new DataGridViewTextBoxColumn() { DataPropertyName = "Id", Visible = false };
            column[1] = new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "Name" };
            column[2] = new DataGridViewTextBoxColumn() { DataPropertyName = "Type", HeaderText = "Type" };
            column[3] = new DataGridViewTextBoxColumn() { DataPropertyName = "Weight", HeaderText = "Weight" };
            column[4] = new DataGridViewTextBoxColumn() { DataPropertyName = "KcalPer100g", HeaderText = "Kcal (100g)" };
            column[5] = new DataGridViewTextBoxColumn() { DataPropertyName = "PricePer100g", HeaderText = "Price (100g)" };

            IngredientsDataGrid.RowHeadersVisible = false;
            IngredientsDataGrid.Columns.Clear();
            IngredientsDataGrid.Columns.AddRange(column);
        }

        private void ClearInputFields()
        {
            TypeTxt.Text = string.Empty;
            NameTxt.Text = string.Empty;
            WeightNum.Value = 1;
            KcalPer100gNum.Value = 0;
            PricePer100gNum.Value = 0;
        }
        private void ClearAllFields()
        {
            TypeTxt.Text = string.Empty;
            NameTxt.Text = string.Empty;
            WeightNum.Value = 1;
            KcalPer100gNum.Value = 0;
            PricePer100gNum.Value = 0;
            SearchTxt.Text = string.Empty;
        }

        private bool isValid()
        {

            // Used LINQ Expression
            if (_ingredients.Any(i => i.Name.ToLower() == NameTxt.Text.ToLower()))
            {
                MessageBox.Show("Ingredient with name exist", "Error");
                return false;
            }


            if (string.IsNullOrEmpty(NameTxt.Text) || string.IsNullOrEmpty(TypeTxt.Text) || PricePer100gNum.Value <= 0)
            {
                MessageBox.Show("Please fill all fields", "Error");
                return false;
            }

            return true;
        }

        private void ClearAllFieldsBtn_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private async void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            int lengthBeforePause = SearchTxt.Text.Length;
            await Task.Delay(650);
            int lengthAfterPause = SearchTxt.Text.Length;

            if (lengthBeforePause == lengthAfterPause)
                SearchAndRefreshResult();
        }

        private void SearchAndRefreshResult()
        {
            string searchIngredient = SearchTxt.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchIngredient))
                _matchingIngredients = _ingredients;
            else 
                _matchingIngredients = _ingredients.Where(i => i.Name.ToLower().Contains(searchIngredient)).ToList();

            _matchingIngredients = _currentSort switch
            {
                "Name" => _matchingIngredients.OrderBy(i => i.Name).ToList(),
                "Price" => _matchingIngredients.OrderBy(i => i.PricePer100g).ThenBy(i => i.Name).ToList(),
                "Type" => _matchingIngredients.OrderBy(i => i.Type).ThenBy(i => i.Name).ToList(),
                "Weight" => _matchingIngredients.OrderBy(i => i.Weight).ThenBy(i => i.Name).ToList(),
                "Kcal" => _matchingIngredients.OrderBy(i => i.KcalPer100g).ThenBy(i => i.Name).ToList(),
                "None" or _ => _matchingIngredients
            };

            IngredientsDataGrid.DataSource = null;
            IngredientsDataGrid.DataSource = _matchingIngredients;
        }

        private void SortByComboBox()
        {
            SortByCbx.Items.AddRange(new string[]
            {
                "None",
                "Name",
                "Price",
                "Type",
                "Weight",
                "Kcal"
            });

            SortByCbx.SelectedIndex = 0;
        }

        private void SortByCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentSort = SortByCbx.SelectedItem?.ToString() ?? "None";

            SearchAndRefreshResult();
        }
    }
}
