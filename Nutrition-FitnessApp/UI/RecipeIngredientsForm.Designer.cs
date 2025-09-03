namespace Nutrition_FitnessApp.UI
{
    partial class RecipeIngredientsForm
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
            label1 = new Label();
            AllIngredientsLbx = new ListBox();
            AddIngredientsBtn = new Button();
            RecipeTypeLbl = new Label();
            RecipeIngredientsLbx = new ListBox();
            RemoveIngredientBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 32);
            label1.Name = "label1";
            label1.Size = new Size(168, 32);
            label1.TabIndex = 0;
            label1.Text = "All ingredients";
            // 
            // AllIngredientsLbx
            // 
            AllIngredientsLbx.FormattingEnabled = true;
            AllIngredientsLbx.ItemHeight = 32;
            AllIngredientsLbx.Location = new Point(12, 80);
            AllIngredientsLbx.Name = "AllIngredientsLbx";
            AllIngredientsLbx.Size = new Size(270, 324);
            AllIngredientsLbx.TabIndex = 1;
            // 
            // AddIngredientsBtn
            // 
            AddIngredientsBtn.Location = new Point(12, 419);
            AddIngredientsBtn.Name = "AddIngredientsBtn";
            AddIngredientsBtn.Size = new Size(270, 52);
            AddIngredientsBtn.TabIndex = 2;
            AddIngredientsBtn.Text = "Add Ingredient";
            AddIngredientsBtn.UseVisualStyleBackColor = true;
            AddIngredientsBtn.Click += AddIngredientsBtn_Click;
            // 
            // RecipeTypeLbl
            // 
            RecipeTypeLbl.AutoSize = true;
            RecipeTypeLbl.Location = new Point(298, 9);
            RecipeTypeLbl.Name = "RecipeTypeLbl";
            RecipeTypeLbl.Size = new Size(23, 32);
            RecipeTypeLbl.TabIndex = 3;
            RecipeTypeLbl.Text = "/";
            // 
            // RecipeIngredientsLbx
            // 
            RecipeIngredientsLbx.FormattingEnabled = true;
            RecipeIngredientsLbx.ItemHeight = 32;
            RecipeIngredientsLbx.Location = new Point(298, 80);
            RecipeIngredientsLbx.Name = "RecipeIngredientsLbx";
            RecipeIngredientsLbx.Size = new Size(259, 324);
            RecipeIngredientsLbx.TabIndex = 4;
            // 
            // RemoveIngredientBtn
            // 
            RemoveIngredientBtn.Location = new Point(298, 419);
            RemoveIngredientBtn.Name = "RemoveIngredientBtn";
            RemoveIngredientBtn.Size = new Size(259, 52);
            RemoveIngredientBtn.TabIndex = 5;
            RemoveIngredientBtn.Text = "Remove Ingredient";
            RemoveIngredientBtn.UseVisualStyleBackColor = true;
            RemoveIngredientBtn.Click += RemoveIngredientBtn_Click;
            // 
            // RecipeIngredientsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 476);
            Controls.Add(RemoveIngredientBtn);
            Controls.Add(RecipeIngredientsLbx);
            Controls.Add(RecipeTypeLbl);
            Controls.Add(AddIngredientsBtn);
            Controls.Add(AllIngredientsLbx);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "RecipeIngredientsForm";
            Text = "RecipeIngredients";
            Load += RecipeIngredientsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox AllIngredientsLbx;
        private Button AddIngredientsBtn;
        private Label RecipeTypeLbl;
        private ListBox RecipeIngredientsLbx;
        private Button RemoveIngredientBtn;
    }
}