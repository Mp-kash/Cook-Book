namespace Cook_Book.UI
{
    partial class IngredientsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            NameLbl = new Label();
            TypeLbl = new Label();
            WeightLbl = new Label();
            KcalLbl = new Label();
            PriceLbl = new Label();
            NameTxt = new TextBox();
            TypeTxt = new TextBox();
            WeightNum = new NumericUpDown();
            KcalPer100gNum = new NumericUpDown();
            PricePer100gNum = new NumericUpDown();
            AddIngredientBtn = new Button();
            ClearAllFieldsBtn = new Button();
            EditIngredientsBtn = new Button();
            RightPanel = new Panel();
            SortByLbl = new Label();
            SortByCbx = new ComboBox();
            SearchTxt = new TextBox();
            IngredientsDataGrid = new DataGridView();
            LeftPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)WeightNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KcalPer100gNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PricePer100gNum).BeginInit();
            RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IngredientsDataGrid).BeginInit();
            SuspendLayout();
            // 
            // NameLbl
            // 
            NameLbl.AutoSize = true;
            NameLbl.BackColor = Color.FromArgb(32, 45, 64);
            NameLbl.FlatStyle = FlatStyle.Flat;
            NameLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            NameLbl.ForeColor = Color.FromArgb(235, 240, 209);
            NameLbl.Location = new Point(923, 64);
            NameLbl.Name = "NameLbl";
            NameLbl.Size = new Size(85, 32);
            NameLbl.TabIndex = 1;
            NameLbl.Text = "Name:";
            // 
            // TypeLbl
            // 
            TypeLbl.AutoSize = true;
            TypeLbl.BackColor = Color.FromArgb(32, 45, 64);
            TypeLbl.FlatStyle = FlatStyle.Flat;
            TypeLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            TypeLbl.ForeColor = Color.FromArgb(235, 240, 209);
            TypeLbl.Location = new Point(928, 147);
            TypeLbl.Name = "TypeLbl";
            TypeLbl.Size = new Size(71, 32);
            TypeLbl.TabIndex = 2;
            TypeLbl.Text = "Type:";
            // 
            // WeightLbl
            // 
            WeightLbl.AutoSize = true;
            WeightLbl.BackColor = Color.FromArgb(32, 45, 64);
            WeightLbl.FlatStyle = FlatStyle.Flat;
            WeightLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            WeightLbl.ForeColor = Color.FromArgb(235, 240, 209);
            WeightLbl.Location = new Point(923, 234);
            WeightLbl.Name = "WeightLbl";
            WeightLbl.Size = new Size(98, 32);
            WeightLbl.TabIndex = 3;
            WeightLbl.Text = "Weight:";
            // 
            // KcalLbl
            // 
            KcalLbl.AutoSize = true;
            KcalLbl.BackColor = Color.FromArgb(32, 45, 64);
            KcalLbl.FlatStyle = FlatStyle.Flat;
            KcalLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            KcalLbl.ForeColor = Color.FromArgb(235, 240, 209);
            KcalLbl.Location = new Point(923, 316);
            KcalLbl.Name = "KcalLbl";
            KcalLbl.Size = new Size(138, 32);
            KcalLbl.TabIndex = 4;
            KcalLbl.Text = "Kcal (100g):";
            // 
            // PriceLbl
            // 
            PriceLbl.AutoSize = true;
            PriceLbl.BackColor = Color.FromArgb(32, 45, 64);
            PriceLbl.FlatStyle = FlatStyle.Flat;
            PriceLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            PriceLbl.ForeColor = Color.FromArgb(235, 240, 209);
            PriceLbl.Location = new Point(923, 393);
            PriceLbl.Name = "PriceLbl";
            PriceLbl.Size = new Size(146, 32);
            PriceLbl.TabIndex = 5;
            PriceLbl.Text = "Price (100g):";
            // 
            // NameTxt
            // 
            NameTxt.Location = new Point(1065, 57);
            NameTxt.Name = "NameTxt";
            NameTxt.Size = new Size(272, 39);
            NameTxt.TabIndex = 6;
            // 
            // TypeTxt
            // 
            TypeTxt.Location = new Point(1065, 140);
            TypeTxt.Name = "TypeTxt";
            TypeTxt.Size = new Size(272, 39);
            TypeTxt.TabIndex = 7;
            // 
            // WeightNum
            // 
            WeightNum.DecimalPlaces = 2;
            WeightNum.Location = new Point(1065, 227);
            WeightNum.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            WeightNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            WeightNum.Name = "WeightNum";
            WeightNum.Size = new Size(272, 39);
            WeightNum.TabIndex = 8;
            WeightNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // KcalPer100gNum
            // 
            KcalPer100gNum.DecimalPlaces = 2;
            KcalPer100gNum.Location = new Point(1065, 314);
            KcalPer100gNum.Maximum = new decimal(new int[] { 905, 0, 0, 0 });
            KcalPer100gNum.Name = "KcalPer100gNum";
            KcalPer100gNum.Size = new Size(272, 39);
            KcalPer100gNum.TabIndex = 9;
            // 
            // PricePer100gNum
            // 
            PricePer100gNum.DecimalPlaces = 2;
            PricePer100gNum.Location = new Point(1065, 393);
            PricePer100gNum.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            PricePer100gNum.Name = "PricePer100gNum";
            PricePer100gNum.Size = new Size(272, 39);
            PricePer100gNum.TabIndex = 10;
            // 
            // AddIngredientBtn
            // 
            AddIngredientBtn.BackColor = Color.FromArgb(32, 45, 64);
            AddIngredientBtn.FlatAppearance.BorderSize = 0;
            AddIngredientBtn.FlatStyle = FlatStyle.Flat;
            AddIngredientBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            AddIngredientBtn.Location = new Point(928, 456);
            AddIngredientBtn.Name = "AddIngredientBtn";
            AddIngredientBtn.Size = new Size(409, 54);
            AddIngredientBtn.TabIndex = 11;
            AddIngredientBtn.Text = "Add Ingredient";
            AddIngredientBtn.UseVisualStyleBackColor = false;
            AddIngredientBtn.Click += AddIngredientBtn_Click;
            // 
            // ClearAllFieldsBtn
            // 
            ClearAllFieldsBtn.BackColor = Color.FromArgb(32, 45, 64);
            ClearAllFieldsBtn.FlatAppearance.BorderSize = 0;
            ClearAllFieldsBtn.FlatStyle = FlatStyle.Flat;
            ClearAllFieldsBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            ClearAllFieldsBtn.Location = new Point(928, 533);
            ClearAllFieldsBtn.Name = "ClearAllFieldsBtn";
            ClearAllFieldsBtn.Size = new Size(409, 50);
            ClearAllFieldsBtn.TabIndex = 12;
            ClearAllFieldsBtn.Text = "Clear All Fields";
            ClearAllFieldsBtn.UseVisualStyleBackColor = false;
            ClearAllFieldsBtn.Click += ClearAllFieldsBtn_Click;
            // 
            // EditIngredientsBtn
            // 
            EditIngredientsBtn.BackColor = Color.FromArgb(32, 45, 64);
            EditIngredientsBtn.FlatAppearance.BorderSize = 0;
            EditIngredientsBtn.FlatStyle = FlatStyle.Flat;
            EditIngredientsBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            EditIngredientsBtn.Location = new Point(928, 456);
            EditIngredientsBtn.Name = "EditIngredientsBtn";
            EditIngredientsBtn.Size = new Size(409, 54);
            EditIngredientsBtn.TabIndex = 16;
            EditIngredientsBtn.Text = "Edit Ingredients";
            EditIngredientsBtn.UseVisualStyleBackColor = false;
            EditIngredientsBtn.Click += EditIngredientsBtn_Click;
            // 
            // RightPanel
            // 
            RightPanel.BackColor = Color.FromArgb(32, 45, 64);
            RightPanel.Controls.Add(SortByLbl);
            RightPanel.Controls.Add(SortByCbx);
            RightPanel.Controls.Add(EditIngredientsBtn);
            RightPanel.Controls.Add(AddIngredientBtn);
            RightPanel.Controls.Add(SearchTxt);
            RightPanel.Controls.Add(ClearAllFieldsBtn);
            RightPanel.Controls.Add(IngredientsDataGrid);
            RightPanel.Controls.Add(LeftPanel);
            RightPanel.Dock = DockStyle.Fill;
            RightPanel.Location = new Point(0, 0);
            RightPanel.Name = "RightPanel";
            RightPanel.Size = new Size(1349, 595);
            RightPanel.TabIndex = 18;
            // 
            // SortByLbl
            // 
            SortByLbl.AutoSize = true;
            SortByLbl.Location = new Point(597, 15);
            SortByLbl.Name = "SortByLbl";
            SortByLbl.Size = new Size(95, 32);
            SortByLbl.TabIndex = 14;
            SortByLbl.Text = "Sort by:";
            // 
            // SortByCbx
            // 
            SortByCbx.DropDownStyle = ComboBoxStyle.DropDownList;
            SortByCbx.FormattingEnabled = true;
            SortByCbx.Location = new Point(719, 12);
            SortByCbx.Name = "SortByCbx";
            SortByCbx.Size = new Size(182, 40);
            SortByCbx.TabIndex = 15;
            SortByCbx.SelectedIndexChanged += SortByCbx_SelectedIndexChanged;
            // 
            // SearchTxt
            // 
            SearchTxt.ForeColor = Color.White;
            SearchTxt.Location = new Point(12, 12);
            SearchTxt.Name = "SearchTxt";
            SearchTxt.PlaceholderText = "Search...";
            SearchTxt.Size = new Size(496, 39);
            SearchTxt.TabIndex = 13;
            SearchTxt.TextChanged += SearchTxt_TextChanged;
            // 
            // IngredientsDataGrid
            // 
            IngredientsDataGrid.AllowUserToResizeColumns = false;
            IngredientsDataGrid.AllowUserToResizeRows = false;
            IngredientsDataGrid.BorderStyle = BorderStyle.None;
            IngredientsDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            IngredientsDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            IngredientsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            IngredientsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            IngredientsDataGrid.EnableHeadersVisualStyles = false;
            IngredientsDataGrid.Location = new Point(12, 64);
            IngredientsDataGrid.Name = "IngredientsDataGrid";
            IngredientsDataGrid.RowHeadersWidth = 62;
            IngredientsDataGrid.RowTemplate.Height = 40;
            IngredientsDataGrid.Size = new Size(889, 519);
            IngredientsDataGrid.TabIndex = 0;
            IngredientsDataGrid.CellClick += IngredientsDataGrid_CellClick;
            // 
            // LeftPanel
            // 
            LeftPanel.Dock = DockStyle.Left;
            LeftPanel.Location = new Point(0, 0);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.Size = new Size(917, 595);
            LeftPanel.TabIndex = 17;
            // 
            // IngredientsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1349, 595);
            Controls.Add(PricePer100gNum);
            Controls.Add(KcalPer100gNum);
            Controls.Add(WeightNum);
            Controls.Add(TypeTxt);
            Controls.Add(NameTxt);
            Controls.Add(PriceLbl);
            Controls.Add(KcalLbl);
            Controls.Add(WeightLbl);
            Controls.Add(TypeLbl);
            Controls.Add(NameLbl);
            Controls.Add(RightPanel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "IngredientsForm";
            Text = "My Fridge";
            Load += IngredientsForm_Load;
            ((System.ComponentModel.ISupportInitialize)WeightNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)KcalPer100gNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)PricePer100gNum).EndInit();
            RightPanel.ResumeLayout(false);
            RightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IngredientsDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label NameLbl;
        private Label TypeLbl;
        private Label WeightLbl;
        private Label KcalLbl;
        private Label PriceLbl;
        private TextBox NameTxt;
        private TextBox TypeTxt;
        private NumericUpDown WeightNum;
        private NumericUpDown KcalPer100gNum;
        private NumericUpDown PricePer100gNum;
        private Button AddIngredientBtn;
        private Button ClearAllFieldsBtn;
        private Button EditIngredientsBtn;
        private Panel RightPanel;
        private Label SortByLbl;
        private ComboBox SortByCbx;
        private TextBox SearchTxt;
        private DataGridView IngredientsDataGrid;
        private Panel LeftPanel;
    }
}
