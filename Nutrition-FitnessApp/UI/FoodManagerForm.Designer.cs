namespace Nutrition_FitnessApp.UI
{
    partial class FoodManagerForm
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
            components = new System.ComponentModel.Container();
            AvailableBtn = new Button();
            RecipesLbx = new ListBox();
            PrepareFoodBtn = new Button();
            DescriptionTxt = new RichTextBox();
            UnavailableBtn = new Button();
            IngredientsLbx = new ListBox();
            PictureBox = new PictureBox();
            TotalCalories = new Label();
            TotalPrice = new Label();
            Ingredients = new Label();
            TotalCaloriesLbl = new Label();
            TotalPriceLbl = new Label();
            CreateShoppingListBtn = new Button();
            LeftPanel = new Panel();
            RightPanel = new Panel();
            IconDisplay = new PictureBox();
            Healthy = new Label();
            NotificationIcon = new PictureBox();
            ItemsToDisplayLbl = new Label();
            NotificationTooltip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            LeftPanel.SuspendLayout();
            RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IconDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NotificationIcon).BeginInit();
            SuspendLayout();
            // 
            // AvailableBtn
            // 
            AvailableBtn.BackColor = Color.FromArgb(41, 89, 79);
            AvailableBtn.FlatAppearance.BorderSize = 0;
            AvailableBtn.FlatStyle = FlatStyle.Flat;
            AvailableBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            AvailableBtn.ForeColor = Color.White;
            AvailableBtn.Location = new Point(12, 12);
            AvailableBtn.Name = "AvailableBtn";
            AvailableBtn.Size = new Size(152, 60);
            AvailableBtn.TabIndex = 0;
            AvailableBtn.Text = "Available";
            AvailableBtn.UseVisualStyleBackColor = false;
            AvailableBtn.Click += AvailableBtn_Click;
            // 
            // RecipesLbx
            // 
            RecipesLbx.BorderStyle = BorderStyle.None;
            RecipesLbx.FormattingEnabled = true;
            RecipesLbx.ItemHeight = 32;
            RecipesLbx.Location = new Point(12, 78);
            RecipesLbx.Name = "RecipesLbx";
            RecipesLbx.Size = new Size(317, 416);
            RecipesLbx.TabIndex = 2;
            RecipesLbx.SelectedIndexChanged += RecipesLbx_SelectedIndexChanged;
            // 
            // PrepareFoodBtn
            // 
            PrepareFoodBtn.BackColor = Color.FromArgb(41, 89, 79);
            PrepareFoodBtn.FlatAppearance.BorderSize = 0;
            PrepareFoodBtn.FlatStyle = FlatStyle.Flat;
            PrepareFoodBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PrepareFoodBtn.ForeColor = Color.White;
            PrepareFoodBtn.Location = new Point(12, 504);
            PrepareFoodBtn.Name = "PrepareFoodBtn";
            PrepareFoodBtn.Size = new Size(317, 54);
            PrepareFoodBtn.TabIndex = 4;
            PrepareFoodBtn.Text = "Prepare Food";
            PrepareFoodBtn.UseVisualStyleBackColor = false;
            PrepareFoodBtn.Click += PrepareFoodBtn_Click;
            // 
            // DescriptionTxt
            // 
            DescriptionTxt.BorderStyle = BorderStyle.None;
            DescriptionTxt.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DescriptionTxt.Location = new Point(352, 344);
            DescriptionTxt.Name = "DescriptionTxt";
            DescriptionTxt.ReadOnly = true;
            DescriptionTxt.Size = new Size(368, 214);
            DescriptionTxt.TabIndex = 5;
            DescriptionTxt.Text = "";
            // 
            // UnavailableBtn
            // 
            UnavailableBtn.FlatAppearance.BorderSize = 0;
            UnavailableBtn.FlatStyle = FlatStyle.Flat;
            UnavailableBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            UnavailableBtn.ForeColor = Color.White;
            UnavailableBtn.Location = new Point(170, 12);
            UnavailableBtn.Name = "UnavailableBtn";
            UnavailableBtn.Size = new Size(159, 60);
            UnavailableBtn.TabIndex = 6;
            UnavailableBtn.Text = "Unavailable";
            UnavailableBtn.UseVisualStyleBackColor = true;
            UnavailableBtn.Click += UnavailableBtn_Click;
            // 
            // IngredientsLbx
            // 
            IngredientsLbx.BorderStyle = BorderStyle.None;
            IngredientsLbx.FormattingEnabled = true;
            IngredientsLbx.ItemHeight = 32;
            IngredientsLbx.Location = new Point(352, 78);
            IngredientsLbx.Name = "IngredientsLbx";
            IngredientsLbx.Size = new Size(368, 256);
            IngredientsLbx.TabIndex = 7;
            // 
            // PictureBox
            // 
            PictureBox.Location = new Point(726, 344);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(298, 214);
            PictureBox.TabIndex = 8;
            PictureBox.TabStop = false;
            // 
            // TotalCalories
            // 
            TotalCalories.AutoSize = true;
            TotalCalories.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            TotalCalories.Location = new Point(726, 43);
            TotalCalories.Name = "TotalCalories";
            TotalCalories.Size = new Size(162, 32);
            TotalCalories.TabIndex = 9;
            TotalCalories.Text = "Total calories:";
            // 
            // TotalPrice
            // 
            TotalPrice.AutoSize = true;
            TotalPrice.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            TotalPrice.Location = new Point(726, 89);
            TotalPrice.Name = "TotalPrice";
            TotalPrice.Size = new Size(133, 32);
            TotalPrice.TabIndex = 10;
            TotalPrice.Text = "Total price:";
            // 
            // Ingredients
            // 
            Ingredients.AutoSize = true;
            Ingredients.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Ingredients.Location = new Point(352, 26);
            Ingredients.Name = "Ingredients";
            Ingredients.Size = new Size(137, 32);
            Ingredients.TabIndex = 11;
            Ingredients.Text = "Ingredients";
            // 
            // TotalCaloriesLbl
            // 
            TotalCaloriesLbl.AutoSize = true;
            TotalCaloriesLbl.Location = new Point(889, 43);
            TotalCaloriesLbl.Name = "TotalCaloriesLbl";
            TotalCaloriesLbl.Size = new Size(23, 32);
            TotalCaloriesLbl.TabIndex = 12;
            TotalCaloriesLbl.Text = "/";
            // 
            // TotalPriceLbl
            // 
            TotalPriceLbl.AutoSize = true;
            TotalPriceLbl.Location = new Point(889, 89);
            TotalPriceLbl.Name = "TotalPriceLbl";
            TotalPriceLbl.Size = new Size(23, 32);
            TotalPriceLbl.TabIndex = 13;
            TotalPriceLbl.Text = "/";
            // 
            // CreateShoppingListBtn
            // 
            CreateShoppingListBtn.FlatAppearance.BorderSize = 0;
            CreateShoppingListBtn.FlatStyle = FlatStyle.Flat;
            CreateShoppingListBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            CreateShoppingListBtn.ForeColor = Color.White;
            CreateShoppingListBtn.Location = new Point(12, 504);
            CreateShoppingListBtn.Name = "CreateShoppingListBtn";
            CreateShoppingListBtn.Size = new Size(317, 54);
            CreateShoppingListBtn.TabIndex = 14;
            CreateShoppingListBtn.Text = "Create ShoppingList";
            CreateShoppingListBtn.UseVisualStyleBackColor = true;
            CreateShoppingListBtn.Click += CreateShoppingListBtn_Click;
            // 
            // LeftPanel
            // 
            LeftPanel.Controls.Add(CreateShoppingListBtn);
            LeftPanel.Controls.Add(PrepareFoodBtn);
            LeftPanel.Controls.Add(RecipesLbx);
            LeftPanel.Dock = DockStyle.Left;
            LeftPanel.Location = new Point(0, 0);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.Size = new Size(345, 566);
            LeftPanel.TabIndex = 15;
            // 
            // RightPanel
            // 
            RightPanel.Controls.Add(IconDisplay);
            RightPanel.Controls.Add(Healthy);
            RightPanel.Controls.Add(NotificationIcon);
            RightPanel.Controls.Add(ItemsToDisplayLbl);
            RightPanel.Controls.Add(PictureBox);
            RightPanel.Controls.Add(Ingredients);
            RightPanel.Controls.Add(TotalCaloriesLbl);
            RightPanel.Controls.Add(TotalPriceLbl);
            RightPanel.Controls.Add(IngredientsLbx);
            RightPanel.Controls.Add(DescriptionTxt);
            RightPanel.Controls.Add(TotalCalories);
            RightPanel.Controls.Add(TotalPrice);
            RightPanel.Dock = DockStyle.Fill;
            RightPanel.Location = new Point(0, 0);
            RightPanel.Name = "RightPanel";
            RightPanel.Size = new Size(1038, 566);
            RightPanel.TabIndex = 16;
            // 
            // IconDisplay
            // 
            IconDisplay.Image = Properties.Resources.check1;
            IconDisplay.Location = new Point(837, 129);
            IconDisplay.Name = "IconDisplay";
            IconDisplay.Size = new Size(45, 42);
            IconDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            IconDisplay.TabIndex = 16;
            IconDisplay.TabStop = false;
            // 
            // Healthy
            // 
            Healthy.AutoSize = true;
            Healthy.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Healthy.Location = new Point(726, 139);
            Healthy.Name = "Healthy";
            Healthy.Size = new Size(105, 32);
            Healthy.TabIndex = 15;
            Healthy.Text = "Healthy:";
            // 
            // NotificationIcon
            // 
            NotificationIcon.Image = Properties.Resources.notification;
            NotificationIcon.Location = new Point(647, 12);
            NotificationIcon.Name = "NotificationIcon";
            NotificationIcon.Size = new Size(73, 63);
            NotificationIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            NotificationIcon.TabIndex = 14;
            NotificationIcon.TabStop = false;
            NotificationIcon.Visible = false;
            NotificationIcon.MouseEnter += NotificationIcon_MouseEnter;
            NotificationIcon.MouseLeave += NotificationIcon_MouseLeave;
            // 
            // ItemsToDisplayLbl
            // 
            ItemsToDisplayLbl.AutoSize = true;
            ItemsToDisplayLbl.Font = new Font("Segoe UI Historic", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            ItemsToDisplayLbl.Location = new Point(497, 262);
            ItemsToDisplayLbl.Name = "ItemsToDisplayLbl";
            ItemsToDisplayLbl.Size = new Size(358, 48);
            ItemsToDisplayLbl.TabIndex = 0;
            ItemsToDisplayLbl.Text = "No Items To Display";
            // 
            // FoodManagerForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 566);
            Controls.Add(UnavailableBtn);
            Controls.Add(AvailableBtn);
            Controls.Add(LeftPanel);
            Controls.Add(RightPanel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FoodManagerForm";
            Text = "FoodManagerForm";
            Load += FoodManagerForm_Load;
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            LeftPanel.ResumeLayout(false);
            RightPanel.ResumeLayout(false);
            RightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IconDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)NotificationIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button AvailableBtn;
        private ListBox RecipesLbx;
        private Button PrepareFoodBtn;
        private RichTextBox DescriptionTxt;
        private Button UnavailableBtn;
        private ListBox IngredientsLbx;
        private PictureBox PictureBox;
        private Label TotalCalories;
        private Label TotalPrice;
        private Label Ingredients;
        private Label TotalCaloriesLbl;
        private Label TotalPriceLbl;
        private Button CreateShoppingListBtn;
        private Panel LeftPanel;
        private Panel RightPanel;
        private Label ItemsToDisplayLbl;
        private PictureBox NotificationIcon;
        private Label Healthy;
        private PictureBox IconDisplay;
        private ToolTip NotificationTooltip;
    }
}