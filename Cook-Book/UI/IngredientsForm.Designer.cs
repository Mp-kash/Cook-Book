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
            IngredientsDataGrid = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            NameTxt = new TextBox();
            TypeTxt = new TextBox();
            WeightNum = new NumericUpDown();
            KcalPer100gNum = new NumericUpDown();
            PricePer100gNum = new NumericUpDown();
            AddIngredientBtn = new Button();
            ClearAllFieldsBtn = new Button();
            SearchTxt = new TextBox();
            label6 = new Label();
            SortByCbx = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)IngredientsDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WeightNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KcalPer100gNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PricePer100gNum).BeginInit();
            SuspendLayout();
            // 
            // IngredientsDataGrid
            // 
            IngredientsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            IngredientsDataGrid.Location = new Point(12, 64);
            IngredientsDataGrid.Name = "IngredientsDataGrid";
            IngredientsDataGrid.RowHeadersWidth = 62;
            IngredientsDataGrid.Size = new Size(754, 519);
            IngredientsDataGrid.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(792, 64);
            label1.Name = "label1";
            label1.Size = new Size(83, 32);
            label1.TabIndex = 1;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(797, 147);
            label2.Name = "label2";
            label2.Size = new Size(70, 32);
            label2.TabIndex = 2;
            label2.Text = "Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(792, 234);
            label3.Name = "label3";
            label3.Size = new Size(95, 32);
            label3.TabIndex = 3;
            label3.Text = "Weight:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(792, 316);
            label4.Name = "label4";
            label4.Size = new Size(136, 32);
            label4.TabIndex = 4;
            label4.Text = "Kcal (100g):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(792, 393);
            label5.Name = "label5";
            label5.Size = new Size(144, 32);
            label5.TabIndex = 5;
            label5.Text = "Price (100g):";
            // 
            // NameTxt
            // 
            NameTxt.Location = new Point(934, 57);
            NameTxt.Name = "NameTxt";
            NameTxt.Size = new Size(249, 39);
            NameTxt.TabIndex = 6;
            // 
            // TypeTxt
            // 
            TypeTxt.Location = new Point(934, 140);
            TypeTxt.Name = "TypeTxt";
            TypeTxt.Size = new Size(249, 39);
            TypeTxt.TabIndex = 7;
            // 
            // WeightNum
            // 
            WeightNum.DecimalPlaces = 2;
            WeightNum.Location = new Point(934, 227);
            WeightNum.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            WeightNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            WeightNum.Name = "WeightNum";
            WeightNum.Size = new Size(249, 39);
            WeightNum.TabIndex = 8;
            WeightNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // KcalPer100gNum
            // 
            KcalPer100gNum.DecimalPlaces = 2;
            KcalPer100gNum.Location = new Point(934, 314);
            KcalPer100gNum.Maximum = new decimal(new int[] { 905, 0, 0, 0 });
            KcalPer100gNum.Name = "KcalPer100gNum";
            KcalPer100gNum.Size = new Size(249, 39);
            KcalPer100gNum.TabIndex = 9;
            // 
            // PricePer100gNum
            // 
            PricePer100gNum.DecimalPlaces = 2;
            PricePer100gNum.Location = new Point(934, 393);
            PricePer100gNum.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            PricePer100gNum.Name = "PricePer100gNum";
            PricePer100gNum.Size = new Size(249, 39);
            PricePer100gNum.TabIndex = 10;
            // 
            // AddIngredientBtn
            // 
            AddIngredientBtn.Location = new Point(797, 463);
            AddIngredientBtn.Name = "AddIngredientBtn";
            AddIngredientBtn.Size = new Size(386, 54);
            AddIngredientBtn.TabIndex = 11;
            AddIngredientBtn.Text = "Add Ingredient";
            AddIngredientBtn.UseVisualStyleBackColor = true;
            AddIngredientBtn.Click += AddIngredientBtn_Click;
            // 
            // ClearAllFieldsBtn
            // 
            ClearAllFieldsBtn.Location = new Point(797, 533);
            ClearAllFieldsBtn.Name = "ClearAllFieldsBtn";
            ClearAllFieldsBtn.Size = new Size(386, 50);
            ClearAllFieldsBtn.TabIndex = 12;
            ClearAllFieldsBtn.Text = "Clear All Fields";
            ClearAllFieldsBtn.UseVisualStyleBackColor = true;
            ClearAllFieldsBtn.Click += ClearAllFieldsBtn_Click;
            // 
            // SearchTxt
            // 
            SearchTxt.Location = new Point(12, 12);
            SearchTxt.Name = "SearchTxt";
            SearchTxt.PlaceholderText = "Search...";
            SearchTxt.Size = new Size(456, 39);
            SearchTxt.TabIndex = 13;
            SearchTxt.TextChanged += SearchTxt_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(474, 14);
            label6.Name = "label6";
            label6.Size = new Size(95, 32);
            label6.TabIndex = 14;
            label6.Text = "Sort by:";
            // 
            // SortByCbx
            // 
            SortByCbx.DropDownStyle = ComboBoxStyle.DropDownList;
            SortByCbx.FormattingEnabled = true;
            SortByCbx.Location = new Point(584, 11);
            SortByCbx.Name = "SortByCbx";
            SortByCbx.Size = new Size(182, 40);
            SortByCbx.TabIndex = 15;
            SortByCbx.SelectedIndexChanged += SortByCbx_SelectedIndexChanged;
            // 
            // IngredientsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1204, 595);
            Controls.Add(SortByCbx);
            Controls.Add(label6);
            Controls.Add(SearchTxt);
            Controls.Add(ClearAllFieldsBtn);
            Controls.Add(AddIngredientBtn);
            Controls.Add(PricePer100gNum);
            Controls.Add(KcalPer100gNum);
            Controls.Add(WeightNum);
            Controls.Add(TypeTxt);
            Controls.Add(NameTxt);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(IngredientsDataGrid);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "IngredientsForm";
            Text = "My Fridge";
            Load += IngredientsForm_Load;
            ((System.ComponentModel.ISupportInitialize)IngredientsDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)WeightNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)KcalPer100gNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)PricePer100gNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView IngredientsDataGrid;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox NameTxt;
        private TextBox TypeTxt;
        private NumericUpDown WeightNum;
        private NumericUpDown KcalPer100gNum;
        private NumericUpDown PricePer100gNum;
        private Button AddIngredientBtn;
        private Button ClearAllFieldsBtn;
        private TextBox SearchTxt;
        private Label label6;
        private ComboBox SortByCbx;
    }
}
