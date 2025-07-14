namespace Cook_Book.UI
{
    partial class RecipesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RecipesGrid = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            NameTxt = new TextBox();
            DescriptionTxt = new RichTextBox();
            ImageBox = new PictureBox();
            AddRecipeBtn = new Button();
            ClearAllFieldsBtn = new Button();
            AddRecipeTypeBtn = new Button();
            RecipeTypeCbx = new ComboBox();
            RecipeFilterCbx = new ComboBox();
            EditRecipeBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)RecipesGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ImageBox).BeginInit();
            SuspendLayout();
            // 
            // RecipesGrid
            // 
            RecipesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RecipesGrid.Location = new Point(12, 58);
            RecipesGrid.Name = "RecipesGrid";
            RecipesGrid.RowHeadersWidth = 62;
            RecipesGrid.Size = new Size(882, 537);
            RecipesGrid.TabIndex = 0;
            RecipesGrid.CellClick += RecipesGrid_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(900, 14);
            label1.Name = "label1";
            label1.Size = new Size(83, 32);
            label1.TabIndex = 1;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(900, 64);
            label2.Name = "label2";
            label2.Size = new Size(70, 32);
            label2.TabIndex = 2;
            label2.Text = "Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(900, 113);
            label3.Name = "label3";
            label3.Size = new Size(140, 32);
            label3.TabIndex = 3;
            label3.Text = "Description:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(900, 302);
            label4.Name = "label4";
            label4.Size = new Size(85, 32);
            label4.TabIndex = 4;
            label4.Text = "Image:";
            // 
            // NameTxt
            // 
            NameTxt.Location = new Point(1046, 14);
            NameTxt.Name = "NameTxt";
            NameTxt.Size = new Size(315, 39);
            NameTxt.TabIndex = 5;
            // 
            // DescriptionTxt
            // 
            DescriptionTxt.Location = new Point(1046, 110);
            DescriptionTxt.Name = "DescriptionTxt";
            DescriptionTxt.Size = new Size(315, 160);
            DescriptionTxt.TabIndex = 7;
            DescriptionTxt.Text = "";
            // 
            // ImageBox
            // 
            ImageBox.Location = new Point(1046, 276);
            ImageBox.Name = "ImageBox";
            ImageBox.Size = new Size(315, 197);
            ImageBox.TabIndex = 8;
            ImageBox.TabStop = false;
            ImageBox.Click += ImageBox_Click;
            // 
            // AddRecipeBtn
            // 
            AddRecipeBtn.Location = new Point(914, 479);
            AddRecipeBtn.Name = "AddRecipeBtn";
            AddRecipeBtn.Size = new Size(447, 55);
            AddRecipeBtn.TabIndex = 9;
            AddRecipeBtn.Text = "Add Recipe";
            AddRecipeBtn.UseVisualStyleBackColor = true;
            AddRecipeBtn.Click += AddRecipeBtn_Click;
            // 
            // ClearAllFieldsBtn
            // 
            ClearAllFieldsBtn.Location = new Point(914, 540);
            ClearAllFieldsBtn.Name = "ClearAllFieldsBtn";
            ClearAllFieldsBtn.Size = new Size(447, 55);
            ClearAllFieldsBtn.TabIndex = 10;
            ClearAllFieldsBtn.Text = "Clear all Fields";
            ClearAllFieldsBtn.UseVisualStyleBackColor = true;
            ClearAllFieldsBtn.Click += ClearAllFieldsBtn_Click;
            // 
            // AddRecipeTypeBtn
            // 
            AddRecipeTypeBtn.Location = new Point(1229, 64);
            AddRecipeTypeBtn.Name = "AddRecipeTypeBtn";
            AddRecipeTypeBtn.Size = new Size(132, 40);
            AddRecipeTypeBtn.TabIndex = 11;
            AddRecipeTypeBtn.Text = "Add";
            AddRecipeTypeBtn.UseVisualStyleBackColor = true;
            AddRecipeTypeBtn.Click += AddRecipeTypeBtn_Click;
            // 
            // RecipeTypeCbx
            // 
            RecipeTypeCbx.DropDownStyle = ComboBoxStyle.DropDownList;
            RecipeTypeCbx.FormattingEnabled = true;
            RecipeTypeCbx.Location = new Point(1046, 64);
            RecipeTypeCbx.Name = "RecipeTypeCbx";
            RecipeTypeCbx.Size = new Size(177, 40);
            RecipeTypeCbx.TabIndex = 12;
            // 
            // RecipeFilterCbx
            // 
            RecipeFilterCbx.DropDownStyle = ComboBoxStyle.DropDownList;
            RecipeFilterCbx.FormattingEnabled = true;
            RecipeFilterCbx.Location = new Point(12, 12);
            RecipeFilterCbx.Name = "RecipeFilterCbx";
            RecipeFilterCbx.Size = new Size(882, 40);
            RecipeFilterCbx.TabIndex = 13;
            RecipeFilterCbx.SelectedIndexChanged += RecipeFilterCbx_SelectedIndexChanged;
            // 
            // EditRecipeBtn
            // 
            EditRecipeBtn.Location = new Point(914, 479);
            EditRecipeBtn.Name = "EditRecipeBtn";
            EditRecipeBtn.Size = new Size(447, 55);
            EditRecipeBtn.TabIndex = 14;
            EditRecipeBtn.Text = "Edit Recipe";
            EditRecipeBtn.UseVisualStyleBackColor = true;
            EditRecipeBtn.Click += EditRecipeBtn_Click;
            // 
            // RecipesForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1377, 602);
            Controls.Add(EditRecipeBtn);
            Controls.Add(RecipeFilterCbx);
            Controls.Add(RecipeTypeCbx);
            Controls.Add(AddRecipeTypeBtn);
            Controls.Add(ClearAllFieldsBtn);
            Controls.Add(AddRecipeBtn);
            Controls.Add(ImageBox);
            Controls.Add(DescriptionTxt);
            Controls.Add(NameTxt);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(RecipesGrid);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "RecipesForm";
            Text = "RecipesForm";
            Load += RecipesForm_Load;
            ((System.ComponentModel.ISupportInitialize)RecipesGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)ImageBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView RecipesGrid;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox NameTxt;
        private RichTextBox DescriptionTxt;
        private PictureBox ImageBox;
        private Button AddRecipeBtn;
        private Button ClearAllFieldsBtn;
        private Button AddRecipeTypeBtn;
        private ComboBox RecipeTypeCbx;
        private ComboBox RecipeFilterCbx;
        private Button EditRecipeBtn;
    }
}