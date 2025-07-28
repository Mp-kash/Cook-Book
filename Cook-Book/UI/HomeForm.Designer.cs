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
            FridgeIngredientsBtn.Location = new Point(30, 41);
            FridgeIngredientsBtn.Name = "FridgeIngredientsBtn";
            FridgeIngredientsBtn.Size = new Size(340, 79);
            FridgeIngredientsBtn.TabIndex = 0;
            FridgeIngredientsBtn.Text = "Fridge Ingredients";
            FridgeIngredientsBtn.UseVisualStyleBackColor = true;
            FridgeIngredientsBtn.Click += FridgeIngredientsBtn_Click;
            // 
            // RecipesBtn
            // 
            RecipesBtn.Location = new Point(30, 142);
            RecipesBtn.Name = "RecipesBtn";
            RecipesBtn.Size = new Size(340, 79);
            RecipesBtn.TabIndex = 1;
            RecipesBtn.Text = "Recipes";
            RecipesBtn.UseVisualStyleBackColor = true;
            RecipesBtn.Click += RecipesBtn_Click;
            // 
            // FoodManagerBtn
            // 
            FoodManagerBtn.Location = new Point(30, 240);
            FoodManagerBtn.Name = "FoodManagerBtn";
            FoodManagerBtn.Size = new Size(340, 79);
            FoodManagerBtn.TabIndex = 2;
            FoodManagerBtn.Text = "FoodManager";
            FoodManagerBtn.UseVisualStyleBackColor = true;
            FoodManagerBtn.Click += FoodManagerBtn_Click;
            // 
            // NotificationIcon
            // 
            NotificationIcon.Image = Properties.Resources.notification;
            NotificationIcon.Location = new Point(157, 366);
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
            ClientSize = new Size(398, 464);
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