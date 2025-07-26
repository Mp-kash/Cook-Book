namespace Cook_Book.UI
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
            AvailableBtn = new Button();
            RecipesLbx = new ListBox();
            PrepareFoodBtn = new Button();
            DescriptionTxt = new RichTextBox();
            UnavailableBtn = new Button();
            IngredientsLbx = new ListBox();
            PictureBox = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            TotalCaloriesLbl = new Label();
            TotalPriceLbl = new Label();
            CreateShoppingListBtn = new Button();
            LeftPanel = new Panel();
            RightPanel = new Panel();
            IconDisplay = new PictureBox();
            label4 = new Label();
            NotificationIcon = new PictureBox();
            ItemsToDisplayLbl = new Label();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IconDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NotificationIcon).BeginInit();
            SuspendLayout();
            // 
            // AvailableBtn
            // 
            AvailableBtn.Location = new Point(12, 12);
            AvailableBtn.Name = "AvailableBtn";
            AvailableBtn.Size = new Size(152, 60);
            AvailableBtn.TabIndex = 0;
            AvailableBtn.Text = "Available";
            AvailableBtn.UseVisualStyleBackColor = true;
            AvailableBtn.Click += AvailableBtn_Click;
            // 
            // RecipesLbx
            // 
            RecipesLbx.FormattingEnabled = true;
            RecipesLbx.ItemHeight = 32;
            RecipesLbx.Location = new Point(12, 78);
            RecipesLbx.Name = "RecipesLbx";
            RecipesLbx.Size = new Size(317, 420);
            RecipesLbx.TabIndex = 2;
            RecipesLbx.SelectedIndexChanged += RecipesLbx_SelectedIndexChanged;
            // 
            // PrepareFoodBtn
            // 
            PrepareFoodBtn.Location = new Point(12, 504);
            PrepareFoodBtn.Name = "PrepareFoodBtn";
            PrepareFoodBtn.Size = new Size(317, 54);
            PrepareFoodBtn.TabIndex = 4;
            PrepareFoodBtn.Text = "Prepare Food";
            PrepareFoodBtn.UseVisualStyleBackColor = true;
            PrepareFoodBtn.Click += PrepareFoodBtn_Click;
            // 
            // DescriptionTxt
            // 
            DescriptionTxt.Location = new Point(352, 344);
            DescriptionTxt.Name = "DescriptionTxt";
            DescriptionTxt.ReadOnly = true;
            DescriptionTxt.Size = new Size(368, 214);
            DescriptionTxt.TabIndex = 5;
            DescriptionTxt.Text = "";
            // 
            // UnavailableBtn
            // 
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
            IngredientsLbx.FormattingEnabled = true;
            IngredientsLbx.ItemHeight = 32;
            IngredientsLbx.Location = new Point(352, 78);
            IngredientsLbx.Name = "IngredientsLbx";
            IngredientsLbx.Size = new Size(368, 260);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(726, 43);
            label1.Name = "label1";
            label1.Size = new Size(157, 32);
            label1.TabIndex = 9;
            label1.Text = "Total calories:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(726, 89);
            label2.Name = "label2";
            label2.Size = new Size(129, 32);
            label2.TabIndex = 10;
            label2.Text = "Total price:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(352, 26);
            label3.Name = "label3";
            label3.Size = new Size(134, 32);
            label3.TabIndex = 11;
            label3.Text = "Ingredients";
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
            LeftPanel.Dock = DockStyle.Left;
            LeftPanel.Location = new Point(0, 0);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.Size = new Size(345, 566);
            LeftPanel.TabIndex = 15;
            // 
            // RightPanel
            // 
            RightPanel.Controls.Add(IconDisplay);
            RightPanel.Controls.Add(label4);
            RightPanel.Controls.Add(NotificationIcon);
            RightPanel.Controls.Add(ItemsToDisplayLbl);
            RightPanel.Controls.Add(PictureBox);
            RightPanel.Controls.Add(label3);
            RightPanel.Controls.Add(TotalCaloriesLbl);
            RightPanel.Controls.Add(TotalPriceLbl);
            RightPanel.Controls.Add(IngredientsLbx);
            RightPanel.Controls.Add(DescriptionTxt);
            RightPanel.Controls.Add(label1);
            RightPanel.Controls.Add(label2);
            RightPanel.Dock = DockStyle.Fill;
            RightPanel.Location = new Point(0, 0);
            RightPanel.Name = "RightPanel";
            RightPanel.Size = new Size(1038, 566);
            RightPanel.TabIndex = 16;
            // 
            // IconDisplay
            // 
            IconDisplay.Image = Properties.Resources.check1;
            IconDisplay.Location = new Point(838, 129);
            IconDisplay.Name = "IconDisplay";
            IconDisplay.Size = new Size(45, 42);
            IconDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            IconDisplay.TabIndex = 16;
            IconDisplay.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(726, 139);
            label4.Name = "label4";
            label4.Size = new Size(101, 32);
            label4.TabIndex = 15;
            label4.Text = "Healthy:";
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
            // 
            // ItemsToDisplayLbl
            // 
            ItemsToDisplayLbl.AutoSize = true;
            ItemsToDisplayLbl.Font = new Font("Segoe UI Historic", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            ItemsToDisplayLbl.Location = new Point(497, 262);
            ItemsToDisplayLbl.Name = "ItemsToDisplayLbl";
            ItemsToDisplayLbl.Size = new Size(326, 45);
            ItemsToDisplayLbl.TabIndex = 0;
            ItemsToDisplayLbl.Text = "No Items To Display";
            // 
            // FoodManagerForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 566);
            Controls.Add(CreateShoppingListBtn);
            Controls.Add(UnavailableBtn);
            Controls.Add(PrepareFoodBtn);
            Controls.Add(RecipesLbx);
            Controls.Add(AvailableBtn);
            Controls.Add(LeftPanel);
            Controls.Add(RightPanel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FoodManagerForm";
            Text = "FoodManagerForm";
            Load += FoodManagerForm_Load;
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label TotalCaloriesLbl;
        private Label TotalPriceLbl;
        private Button CreateShoppingListBtn;
        private Panel LeftPanel;
        private Panel RightPanel;
        private Label ItemsToDisplayLbl;
        private PictureBox NotificationIcon;
        private Label label4;
        private PictureBox IconDisplay;
    }
}