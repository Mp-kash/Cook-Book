namespace Nutrition_FitnessApp.UI
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            RecipesGrid = new DataGridView();
            NameLbl = new Label();
            TypeLbl = new Label();
            DescriptionLbl = new Label();
            ImageLbl = new Label();
            NameTxt = new TextBox();
            DescriptionTxt = new RichTextBox();
            ImageBox = new PictureBox();
            ImageContextMenu = new ContextMenuStrip(components);
            removeImageToolStripMenuItem = new ToolStripMenuItem();
            AddRecipeBtn = new Button();
            ClearAllFieldsBtn = new Button();
            AddRecipeTypeBtn = new Button();
            RecipeTypeCbx = new ComboBox();
            RecipeFilterCbx = new ComboBox();
            EditRecipeBtn = new Button();
            RightPanel = new Panel();
            LeftPanel = new Panel();
            theme2Btn = new Button();
            theme1Btn = new Button();
            ((System.ComponentModel.ISupportInitialize)RecipesGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ImageBox).BeginInit();
            ImageContextMenu.SuspendLayout();
            RightPanel.SuspendLayout();
            LeftPanel.SuspendLayout();
            SuspendLayout();
            // 
            // RecipesGrid
            // 
            RecipesGrid.AllowUserToResizeColumns = false;
            RecipesGrid.AllowUserToResizeRows = false;
            RecipesGrid.BorderStyle = BorderStyle.None;
            RecipesGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            RecipesGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(0, 8, 0, 8);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            RecipesGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            RecipesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RecipesGrid.EnableHeadersVisualStyles = false;
            RecipesGrid.Location = new Point(12, 58);
            RecipesGrid.Name = "RecipesGrid";
            RecipesGrid.RowHeadersWidth = 62;
            RecipesGrid.RowTemplate.Height = 39;
            RecipesGrid.Size = new Size(882, 537);
            RecipesGrid.TabIndex = 0;
            RecipesGrid.CellClick += RecipesGrid_CellClick;
            // 
            // NameLbl
            // 
            NameLbl.AutoSize = true;
            NameLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            NameLbl.ForeColor = Color.FromArgb(235, 240, 209);
            NameLbl.Location = new Point(915, 14);
            NameLbl.Name = "NameLbl";
            NameLbl.Size = new Size(85, 32);
            NameLbl.TabIndex = 1;
            NameLbl.Text = "Name:";
            // 
            // TypeLbl
            // 
            TypeLbl.AutoSize = true;
            TypeLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            TypeLbl.ForeColor = Color.FromArgb(235, 240, 209);
            TypeLbl.Location = new Point(915, 68);
            TypeLbl.Name = "TypeLbl";
            TypeLbl.Size = new Size(71, 32);
            TypeLbl.TabIndex = 2;
            TypeLbl.Text = "Type:";
            // 
            // DescriptionLbl
            // 
            DescriptionLbl.AutoSize = true;
            DescriptionLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            DescriptionLbl.ForeColor = Color.FromArgb(235, 240, 209);
            DescriptionLbl.Location = new Point(915, 124);
            DescriptionLbl.Name = "DescriptionLbl";
            DescriptionLbl.Size = new Size(143, 32);
            DescriptionLbl.TabIndex = 3;
            DescriptionLbl.Text = "Description:";
            // 
            // ImageLbl
            // 
            ImageLbl.AutoSize = true;
            ImageLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            ImageLbl.ForeColor = Color.FromArgb(235, 240, 209);
            ImageLbl.Location = new Point(915, 286);
            ImageLbl.Name = "ImageLbl";
            ImageLbl.Size = new Size(88, 32);
            ImageLbl.TabIndex = 4;
            ImageLbl.Text = "Image:";
            // 
            // NameTxt
            // 
            NameTxt.Location = new Point(1059, 11);
            NameTxt.Name = "NameTxt";
            NameTxt.Size = new Size(315, 39);
            NameTxt.TabIndex = 5;
            // 
            // DescriptionTxt
            // 
            DescriptionTxt.Location = new Point(1059, 110);
            DescriptionTxt.Name = "DescriptionTxt";
            DescriptionTxt.Size = new Size(315, 160);
            DescriptionTxt.TabIndex = 7;
            DescriptionTxt.Text = "";
            // 
            // ImageBox
            // 
            ImageBox.ContextMenuStrip = ImageContextMenu;
            ImageBox.Location = new Point(1059, 276);
            ImageBox.Name = "ImageBox";
            ImageBox.Size = new Size(315, 197);
            ImageBox.TabIndex = 8;
            ImageBox.TabStop = false;
            ImageBox.Click += ImageBox_Click;
            // 
            // ImageContextMenu
            // 
            ImageContextMenu.ImageScalingSize = new Size(24, 24);
            ImageContextMenu.Items.AddRange(new ToolStripItem[] { removeImageToolStripMenuItem });
            ImageContextMenu.Name = "ImageContextMenu";
            ImageContextMenu.Size = new Size(204, 36);
            ImageContextMenu.Text = "Remove Image";
            // 
            // removeImageToolStripMenuItem
            // 
            removeImageToolStripMenuItem.Name = "removeImageToolStripMenuItem";
            removeImageToolStripMenuItem.Size = new Size(203, 32);
            removeImageToolStripMenuItem.Text = "Remove Image";
            removeImageToolStripMenuItem.Click += removeImageToolStripMenuItem_Click;
            // 
            // AddRecipeBtn
            // 
            AddRecipeBtn.FlatAppearance.BorderSize = 0;
            AddRecipeBtn.FlatStyle = FlatStyle.Flat;
            AddRecipeBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            AddRecipeBtn.Location = new Point(927, 479);
            AddRecipeBtn.Name = "AddRecipeBtn";
            AddRecipeBtn.Size = new Size(447, 55);
            AddRecipeBtn.TabIndex = 9;
            AddRecipeBtn.Text = "Add Recipe";
            AddRecipeBtn.UseVisualStyleBackColor = true;
            AddRecipeBtn.Click += AddRecipeBtn_Click;
            // 
            // ClearAllFieldsBtn
            // 
            ClearAllFieldsBtn.FlatAppearance.BorderSize = 0;
            ClearAllFieldsBtn.FlatStyle = FlatStyle.Flat;
            ClearAllFieldsBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            ClearAllFieldsBtn.Location = new Point(927, 540);
            ClearAllFieldsBtn.Name = "ClearAllFieldsBtn";
            ClearAllFieldsBtn.Size = new Size(447, 55);
            ClearAllFieldsBtn.TabIndex = 10;
            ClearAllFieldsBtn.Text = "Clear all Fields";
            ClearAllFieldsBtn.UseVisualStyleBackColor = true;
            ClearAllFieldsBtn.Click += ClearAllFieldsBtn_Click;
            // 
            // AddRecipeTypeBtn
            // 
            AddRecipeTypeBtn.FlatAppearance.BorderSize = 0;
            AddRecipeTypeBtn.FlatStyle = FlatStyle.Flat;
            AddRecipeTypeBtn.Location = new Point(1242, 63);
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
            RecipeTypeCbx.FlatStyle = FlatStyle.Flat;
            RecipeTypeCbx.FormattingEnabled = true;
            RecipeTypeCbx.Location = new Point(1059, 64);
            RecipeTypeCbx.Name = "RecipeTypeCbx";
            RecipeTypeCbx.Size = new Size(177, 40);
            RecipeTypeCbx.TabIndex = 12;
            // 
            // RecipeFilterCbx
            // 
            RecipeFilterCbx.DropDownStyle = ComboBoxStyle.DropDownList;
            RecipeFilterCbx.FlatStyle = FlatStyle.Flat;
            RecipeFilterCbx.FormattingEnabled = true;
            RecipeFilterCbx.Location = new Point(12, 12);
            RecipeFilterCbx.Name = "RecipeFilterCbx";
            RecipeFilterCbx.Size = new Size(626, 40);
            RecipeFilterCbx.TabIndex = 13;
            RecipeFilterCbx.SelectedIndexChanged += RecipeFilterCbx_SelectedIndexChanged;
            // 
            // EditRecipeBtn
            // 
            EditRecipeBtn.FlatAppearance.BorderSize = 0;
            EditRecipeBtn.FlatStyle = FlatStyle.Flat;
            EditRecipeBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            EditRecipeBtn.Location = new Point(927, 479);
            EditRecipeBtn.Name = "EditRecipeBtn";
            EditRecipeBtn.Size = new Size(447, 55);
            EditRecipeBtn.TabIndex = 14;
            EditRecipeBtn.Text = "Edit Recipe";
            EditRecipeBtn.UseVisualStyleBackColor = true;
            EditRecipeBtn.Click += EditRecipeBtn_Click;
            // 
            // RightPanel
            // 
            RightPanel.BackColor = Color.FromArgb(32, 45, 64);
            RightPanel.Controls.Add(DescriptionLbl);
            RightPanel.Controls.Add(TypeLbl);
            RightPanel.Controls.Add(EditRecipeBtn);
            RightPanel.Controls.Add(AddRecipeTypeBtn);
            RightPanel.Controls.Add(RecipeTypeCbx);
            RightPanel.Controls.Add(NameTxt);
            RightPanel.Controls.Add(NameLbl);
            RightPanel.Controls.Add(ImageLbl);
            RightPanel.Controls.Add(ImageBox);
            RightPanel.Controls.Add(ClearAllFieldsBtn);
            RightPanel.Controls.Add(DescriptionTxt);
            RightPanel.Controls.Add(AddRecipeBtn);
            RightPanel.Dock = DockStyle.Fill;
            RightPanel.Location = new Point(0, 0);
            RightPanel.Name = "RightPanel";
            RightPanel.Size = new Size(1388, 602);
            RightPanel.TabIndex = 16;
            // 
            // LeftPanel
            // 
            LeftPanel.BackColor = Color.FromArgb(45, 66, 91);
            LeftPanel.Controls.Add(theme2Btn);
            LeftPanel.Controls.Add(theme1Btn);
            LeftPanel.Controls.Add(RecipesGrid);
            LeftPanel.Dock = DockStyle.Left;
            LeftPanel.Location = new Point(0, 0);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.Size = new Size(908, 602);
            LeftPanel.TabIndex = 17;
            // 
            // theme2Btn
            // 
            theme2Btn.Location = new Point(779, 13);
            theme2Btn.Name = "theme2Btn";
            theme2Btn.Size = new Size(115, 38);
            theme2Btn.TabIndex = 1;
            theme2Btn.Text = "theme2";
            theme2Btn.UseVisualStyleBackColor = true;
            theme2Btn.Click += theme2Btn_Click;
            // 
            // theme1Btn
            // 
            theme1Btn.Location = new Point(661, 12);
            theme1Btn.Name = "theme1Btn";
            theme1Btn.Size = new Size(112, 40);
            theme1Btn.TabIndex = 0;
            theme1Btn.Text = "theme1";
            theme1Btn.UseVisualStyleBackColor = true;
            theme1Btn.Click += theme1Btn_Click;
            // 
            // RecipesForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1388, 602);
            Controls.Add(RecipeFilterCbx);
            Controls.Add(LeftPanel);
            Controls.Add(RightPanel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "RecipesForm";
            Text = "RecipesForm";
            Load += RecipesForm_Load;
            ((System.ComponentModel.ISupportInitialize)RecipesGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)ImageBox).EndInit();
            ImageContextMenu.ResumeLayout(false);
            RightPanel.ResumeLayout(false);
            RightPanel.PerformLayout();
            LeftPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView RecipesGrid;
        private Label NameLbl;
        private Label TypeLbl;
        private Label DescriptionLbl;
        private Label ImageLbl;
        private TextBox NameTxt;
        private RichTextBox DescriptionTxt;
        private PictureBox ImageBox;
        private Button AddRecipeBtn;
        private Button ClearAllFieldsBtn;
        private Button AddRecipeTypeBtn;
        private ComboBox RecipeTypeCbx;
        private ComboBox RecipeFilterCbx;
        private Button EditRecipeBtn;
        private ContextMenuStrip ImageContextMenu;
        private ToolStripMenuItem removeImageToolStripMenuItem;
        private Panel RightPanel;
        private Panel LeftPanel;
        private Button theme2Btn;
        private Button theme1Btn;
    }
}