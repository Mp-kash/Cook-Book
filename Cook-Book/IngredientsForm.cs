namespace Cook_Book
{
    public partial class IngredientsForm : Form
    {
        List<Ingredients> ingredientsList = new List<Ingredients>();
        public IngredientsForm()
        {
            InitializeComponent();
            Ingredients ingredients = new Ingredients();
            ingredients.Name = "Onion";
            ingredients.Type = "Vegetable";
            ingredients.Weight = 120;
            ingredients.KcalPer100g = 40;
            ingredients.PricePer100g = 2;
            ingredientsList.Add(ingredients);
            IngredientsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void IngredientsForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void AddIngredientBtn_Click(object sender, EventArgs e)
        {
            if (isFieldEmpty())
                return;

            Ingredients ingredients = new Ingredients(NameTxt.Text, TypeTxt.Text, WeightNum.Value, KcalPer100gNum.Value, PricePer100gNum.Value);
            ingredientsList.Add(ingredients);

            RefreshGrid();
            ClearAllFields();
        }

        private void RefreshGrid()
        {
            IngredientsDataGrid.DataSource = null;
            IngredientsDataGrid.DataSource = ingredientsList;
        }

        private void ClearAllFields()
        {
            TypeTxt.Text = "";
            NameTxt.Text = "";
            WeightNum.Value = 0;
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
