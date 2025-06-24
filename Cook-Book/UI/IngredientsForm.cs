using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DomainModels.Models;

namespace Cook_Book.UI
{
    public partial class IngredientsForm : Form
    {
        IIngredientsRepository _ingredientsRepository;

        public IngredientsForm(IIngredientsRepository ingredientsRepository)
        {
            InitializeComponent();

            _ingredientsRepository=ingredientsRepository;          
        }

        private void IngredientsForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            CustomizeGridAppearance();
        }

        private void AddIngredientBtn_Click(object sender, EventArgs e)
        {
            if (isFieldEmpty())
                return;

            Ingredient ingredients = new Ingredient(NameTxt.Text, TypeTxt.Text, WeightNum.Value, KcalPer100gNum.Value, PricePer100gNum.Value);
            _ingredientsRepository.InsertIngredients(ingredients);

            RefreshGrid();
            ClearAllFields();
        }

        private void CustomizeGridAppearance()
        {
            IngredientsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            IngredientsDataGrid.AutoGenerateColumns = false;

            DataGridViewColumn[] column = new DataGridViewColumn[6];
            column[0] = new DataGridViewTextBoxColumn() { DataPropertyName = "Id", Visible = false };
            column[1] = new DataGridViewTextBoxColumn() { DataPropertyName="Name", HeaderText = "Name" };
            column[2] = new DataGridViewTextBoxColumn() { DataPropertyName = "Type", HeaderText = "Type" };
            column[3] = new DataGridViewTextBoxColumn() { DataPropertyName = "Weight", HeaderText = "Weight" };
            column[4] = new DataGridViewTextBoxColumn() { DataPropertyName = "KcalPer100g", HeaderText = "Kcal (100g)" };
            column[5] = new DataGridViewTextBoxColumn() { DataPropertyName = "PricePer100g", HeaderText = "Price (100g)" };

            IngredientsDataGrid.Columns.Clear();
            IngredientsDataGrid.Columns.AddRange(column);
        }

        private void RefreshGrid()
        {
            IngredientsDataGrid.DataSource = null;
            IngredientsDataGrid.DataSource = _ingredientsRepository.GetIngredients();
        }

        private void ClearAllFields()
        {
            TypeTxt.Text = "";
            NameTxt.Text = "";
            WeightNum.Value = 1;
            KcalPer100gNum.Value  = 0;
            PricePer100gNum.Value = 0;
        }

        private bool isFieldEmpty()
        {
            if(string.IsNullOrEmpty(NameTxt.Text) || string.IsNullOrEmpty(TypeTxt.Text) || WeightNum.Value <= 0 || PricePer100gNum.Value <= 0)
            {
                MessageBox.Show("Please fill all fields", "Error");
                return true;
            }

            return false;
        }
    }
}
