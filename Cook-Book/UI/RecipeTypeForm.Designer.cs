namespace Cook_Book.UI
{
    partial class RecipeTypeForm
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
            RecipeTypeTxt = new TextBox();
            RecipeTypeLbx = new ListBox();
            AddRecipeBtn = new Button();
            RemoveBtn = new Button();
            SuspendLayout();
            // 
            // RecipeTypeTxt
            // 
            RecipeTypeTxt.Location = new Point(12, 12);
            RecipeTypeTxt.Name = "RecipeTypeTxt";
            RecipeTypeTxt.PlaceholderText = "Enter recipe type...";
            RecipeTypeTxt.Size = new Size(300, 39);
            RecipeTypeTxt.TabIndex = 0;
            // 
            // RecipeTypeLbx
            // 
            RecipeTypeLbx.FormattingEnabled = true;
            RecipeTypeLbx.ItemHeight = 32;
            RecipeTypeLbx.Location = new Point(12, 57);
            RecipeTypeLbx.Name = "RecipeTypeLbx";
            RecipeTypeLbx.Size = new Size(300, 324);
            RecipeTypeLbx.TabIndex = 1;
            // 
            // AddRecipeBtn
            // 
            AddRecipeBtn.Location = new Point(12, 387);
            AddRecipeBtn.Name = "AddRecipeBtn";
            AddRecipeBtn.Size = new Size(144, 58);
            AddRecipeBtn.TabIndex = 2;
            AddRecipeBtn.Text = "Add";
            AddRecipeBtn.UseVisualStyleBackColor = true;
            AddRecipeBtn.Click += AddRecipeBtn_Click;
            // 
            // RemoveBtn
            // 
            RemoveBtn.Location = new Point(160, 387);
            RemoveBtn.Name = "RemoveBtn";
            RemoveBtn.Size = new Size(152, 58);
            RemoveBtn.TabIndex = 3;
            RemoveBtn.Text = "Remove";
            RemoveBtn.UseVisualStyleBackColor = true;
            RemoveBtn.Click += RemoveBtn_Click;
            // 
            // RecipeTypeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 457);
            Controls.Add(RemoveBtn);
            Controls.Add(AddRecipeBtn);
            Controls.Add(RecipeTypeLbx);
            Controls.Add(RecipeTypeTxt);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "RecipeTypeForm";
            Text = "RecipeTypeForm";
            Load += RecipeTypeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox RecipeTypeTxt;
        private ListBox RecipeTypeLbx;
        private Button AddRecipeBtn;
        private Button RemoveBtn;
    }
}