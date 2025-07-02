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

        private int _ingredientToEditId = 0;

        public IngredientsForm(IIngredientsRepository ingredientsRepository)
        {
            InitializeComponent();

            _ingredientsRepository = ingredientsRepository;

            // Used Lamda expression to subsribe to the error.
            _ingredientsRepository.ErrorOccurred += exMessage =>
                MessageBox.Show(exMessage, "Error");
        }

        private async void IngredientsForm_Load(object sender, EventArgs e)
        {
            EditIngredientsBtn.Visible = false;
            AddIngredientBtn.Visible = true;
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

            DataGridViewColumn[] column = new DataGridViewColumn[8];
            column[0] = new DataGridViewTextBoxColumn() { DataPropertyName = "Id", Visible = false };
            column[1] = new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "Name" };
            column[2] = new DataGridViewTextBoxColumn() { DataPropertyName = "Type", HeaderText = "Type" };
            column[3] = new DataGridViewTextBoxColumn() { DataPropertyName = "Weight", HeaderText = "Weight" };
            column[4] = new DataGridViewTextBoxColumn() { DataPropertyName = "KcalPer100g", HeaderText = "Kcal (100g)" };
            column[5] = new DataGridViewTextBoxColumn() { DataPropertyName = "PricePer100g", HeaderText = "Price (100g)" };

            // Edit button column
            column[6] = new DataGridViewButtonColumn()
            {
                HeaderText = "",
                Name = "EditBtn",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };

            // Delete button column
            column[7] = new DataGridViewButtonColumn()
            {
                HeaderText = "",
                Name = "DeleteBtn",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };

            IngredientsDataGrid.RowHeadersVisible = false;
            IngredientsDataGrid.Columns.Clear();
            IngredientsDataGrid.Columns.AddRange(column);
        }

        private async void IngredientsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Ingredient clickedData = (Ingredient)IngredientsDataGrid.Rows[e.RowIndex].DataBoundItem;
            if(e.RowIndex >= 0 && e.ColumnIndex == IngredientsDataGrid.Columns["DeleteBtn"].Index)
            {
                // Guard clause
                var result = MessageBox.Show("Are you sure you want to delete ingredient", "Delete Ingredient", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await _ingredientsRepository.DeleteIngredients(clickedData);
                    _ingredients = await _ingredientsRepository.GetIngredients();
                    SearchAndRefreshResult();
                    if(_ingredientToEditId == clickedData.Id)
                    {
                        ClearInputFields();                       
                    }
                }
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == IngredientsDataGrid.Columns["EditBtn"].Index)
                fillFormEdit(clickedData);          
        }

        private void fillFormEdit(Ingredient clickedData)
        {
            _ingredientToEditId = clickedData.Id;

            NameTxt.Text = clickedData.Name;
            TypeTxt.Text = clickedData.Type;
            WeightNum.Value = clickedData.Weight;
            KcalPer100gNum.Value = clickedData.KcalPer100g;
            PricePer100gNum.Value = clickedData.PricePer100g;

            EditIngredientsBtn.Visible = true;
            AddIngredientBtn.Visible = false;
        }
        private async void EditIngredientsBtn_Click(object sender, EventArgs e)
        {
            if (!isValid("ignore"))
                return;

            // Using a Constuctor instead of Object initializer
            Ingredient ingeredientsToEdit = new Ingredient(NameTxt.Text, TypeTxt.Text,WeightNum.Value,KcalPer100gNum.Value,PricePer100gNum.Value, _ingredientToEditId);

            EditIngredientsBtn.Enabled = false;
            await _ingredientsRepository.UpdateIngredients(ingeredientsToEdit);
         // Update the cached ingredient
            _ingredients = await _ingredientsRepository.GetIngredients();
            EditIngredientsBtn.Enabled = true;
            EditIngredientsBtn.Visible = false;
            AddIngredientBtn.Visible = true;


            ClearInputFields();            
            SearchAndRefreshResult();
            _ingredientToEditId = 0;
        }

        private void ClearInputFields()
        {
            TypeTxt.Text = string.Empty;
            NameTxt.Text = string.Empty;
            WeightNum.Value = 1;
            KcalPer100gNum.Value = 0;
            PricePer100gNum.Value = 0;

            EditIngredientsBtn.Visible = false;
            AddIngredientBtn.Visible = true;
            _ingredientToEditId = 0;
        }
        private void ClearAllFields()
        {
            TypeTxt.Text = string.Empty;
            NameTxt.Text = string.Empty;
            WeightNum.Value = 1;
            KcalPer100gNum.Value = 0;
            PricePer100gNum.Value = 0;
            SearchTxt.Text = string.Empty;

            EditIngredientsBtn.Visible = false;
            AddIngredientBtn.Visible = true;
            _ingredientToEditId = 0;
        }

        private bool isValid(string? ignore = null)
        {

            if (ignore == null)
            {
                // Used LINQ Expression
                if (_ingredients.Any(i => i.Name.ToLower() == NameTxt.Text.ToLower()))
                {
                    MessageBox.Show("Ingredient with name exist.", "Error");
                    return false;
                }
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
