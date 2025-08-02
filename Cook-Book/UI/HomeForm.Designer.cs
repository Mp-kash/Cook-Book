namespace Cook_Book.UI
{
    partial class HomeForm
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
            FridgeIngredientsBtn = new Button();
            RecipesBtn = new Button();
            FoodManagerBtn = new Button();
            NotificationIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)NotificationIcon).BeginInit();
            SuspendLayout();
            // 
            // FridgeIngredientsBtn
            // 
            FridgeIngredientsBtn.Dock = DockStyle.Top;
            FridgeIngredientsBtn.FlatAppearance.BorderSize = 0;
            FridgeIngredientsBtn.FlatStyle = FlatStyle.Flat;
            FridgeIngredientsBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            FridgeIngredientsBtn.ForeColor = Color.White;
            FridgeIngredientsBtn.Image = Properties.Resources.icons8_fridge_32;
            FridgeIngredientsBtn.ImageAlign = ContentAlignment.MiddleLeft;
            FridgeIngredientsBtn.Location = new Point(0, 0);
            FridgeIngredientsBtn.Name = "FridgeIngredientsBtn";
            FridgeIngredientsBtn.Size = new Size(364, 76);
            FridgeIngredientsBtn.TabIndex = 0;
            FridgeIngredientsBtn.Text = "Fridge Ingredients";
            FridgeIngredientsBtn.UseVisualStyleBackColor = true;
            FridgeIngredientsBtn.Click += FridgeIngredientsBtn_Click;
            // 
            // RecipesBtn
            // 
            RecipesBtn.Dock = DockStyle.Top;
            RecipesBtn.FlatAppearance.BorderSize = 0;
            RecipesBtn.FlatStyle = FlatStyle.Flat;
            RecipesBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            RecipesBtn.ForeColor = Color.White;
            RecipesBtn.Image = Properties.Resources.icons8_recipe_32;
            RecipesBtn.ImageAlign = ContentAlignment.MiddleLeft;
            RecipesBtn.Location = new Point(0, 76);
            RecipesBtn.Name = "RecipesBtn";
            RecipesBtn.Size = new Size(364, 76);
            RecipesBtn.TabIndex = 1;
            RecipesBtn.Text = "Recipes";
            RecipesBtn.UseVisualStyleBackColor = true;
            RecipesBtn.Click += RecipesBtn_Click;
            // 
            // FoodManagerBtn
            // 
            FoodManagerBtn.Dock = DockStyle.Top;
            FoodManagerBtn.FlatAppearance.BorderSize = 0;
            FoodManagerBtn.FlatStyle = FlatStyle.Flat;
            FoodManagerBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            FoodManagerBtn.ForeColor = Color.White;
            FoodManagerBtn.Image = Properties.Resources.icons8_dish_32;
            FoodManagerBtn.ImageAlign = ContentAlignment.MiddleLeft;
            FoodManagerBtn.Location = new Point(0, 152);
            FoodManagerBtn.Name = "FoodManagerBtn";
            FoodManagerBtn.Size = new Size(364, 76);
            FoodManagerBtn.TabIndex = 2;
            FoodManagerBtn.Text = "FoodManager";
            FoodManagerBtn.UseVisualStyleBackColor = true;
            FoodManagerBtn.Click += FoodManagerBtn_Click;
            // 
            // NotificationIcon
            // 
            NotificationIcon.Image = Properties.Resources.notification;
            NotificationIcon.Location = new Point(130, 304);
            NotificationIcon.Name = "NotificationIcon";
            NotificationIcon.Size = new Size(88, 75);
            NotificationIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            NotificationIcon.TabIndex = 3;
            NotificationIcon.TabStop = false;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 66, 91);
            ClientSize = new Size(364, 430);
            Controls.Add(NotificationIcon);
            Controls.Add(FoodManagerBtn);
            Controls.Add(RecipesBtn);
            Controls.Add(FridgeIngredientsBtn);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "HomeForm";
            Text = "HomeForm";
            ((System.ComponentModel.ISupportInitialize)NotificationIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button FridgeIngredientsBtn;
        private Button RecipesBtn;
        private Button FoodManagerBtn;
        private PictureBox NotificationIcon;
    }
}