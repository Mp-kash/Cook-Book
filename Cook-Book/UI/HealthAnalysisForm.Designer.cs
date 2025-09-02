namespace Cook_Book
{
    partial class HealthAnalysisForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            TableLayoutPanel = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            NutritionProgressBar = new ProgressBar();
            FetchNutritionInfoBtn = new Button();
            IngredientsGrid = new DataGridView();
            RecipesCbx = new ComboBox();
            groupBox2 = new GroupBox();
            TotalFatLbl = new Label();
            TotalProteinLbl = new Label();
            label8 = new Label();
            label7 = new Label();
            TotalCarbsLbl = new Label();
            TotalCaloriesLbl = new Label();
            label4 = new Label();
            label3 = new Label();
            NutritionGrid = new DataGridView();
            ScrollPanel = new Panel();
            themedTabControl = new Cook_Book.Services.ThemedTabControl();
            AIAdviceTab = new TabPage();
            AdviceTxt = new RichTextBox();
            GenerateAdviceBtn = new Button();
            ProjectionTab = new TabPage();
            GenerateProjectionBtn = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            TableLayoutPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IngredientsGrid).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NutritionGrid).BeginInit();
            ScrollPanel.SuspendLayout();
            themedTabControl.SuspendLayout();
            AIAdviceTab.SuspendLayout();
            ProjectionTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            TableLayoutPanel.AutoSize = true;
            TableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TableLayoutPanel.ColumnCount = 1;
            TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanel.Controls.Add(groupBox1, 0, 0);
            TableLayoutPanel.Controls.Add(groupBox2, 0, 1);
            TableLayoutPanel.Location = new Point(-1, 0);
            TableLayoutPanel.Name = "TableLayoutPanel";
            TableLayoutPanel.RowCount = 3;
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 390F));
            TableLayoutPanel.RowStyles.Add(new RowStyle());
            TableLayoutPanel.RowStyles.Add(new RowStyle());
            TableLayoutPanel.Size = new Size(830, 796);
            TableLayoutPanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(NutritionProgressBar);
            groupBox1.Controls.Add(FetchNutritionInfoBtn);
            groupBox1.Controls.Add(IngredientsGrid);
            groupBox1.Controls.Add(RecipesCbx);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(824, 384);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Recipe Ingredients";
            // 
            // NutritionProgressBar
            // 
            NutritionProgressBar.Location = new Point(201, 272);
            NutritionProgressBar.Name = "NutritionProgressBar";
            NutritionProgressBar.Size = new Size(423, 50);
            NutritionProgressBar.TabIndex = 3;
            // 
            // FetchNutritionInfoBtn
            // 
            FetchNutritionInfoBtn.FlatAppearance.BorderSize = 0;
            FetchNutritionInfoBtn.FlatStyle = FlatStyle.Flat;
            FetchNutritionInfoBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FetchNutritionInfoBtn.ForeColor = Color.Black;
            FetchNutritionInfoBtn.Location = new Point(235, 328);
            FetchNutritionInfoBtn.Name = "FetchNutritionInfoBtn";
            FetchNutritionInfoBtn.Size = new Size(355, 51);
            FetchNutritionInfoBtn.TabIndex = 2;
            FetchNutritionInfoBtn.Text = " Fetch Nutrition Info";
            FetchNutritionInfoBtn.UseVisualStyleBackColor = true;
            FetchNutritionInfoBtn.Click += FetchNutritionInfoBtn_Click;
            // 
            // IngredientsGrid
            // 
            IngredientsGrid.AllowUserToResizeColumns = false;
            IngredientsGrid.AllowUserToResizeRows = false;
            IngredientsGrid.BorderStyle = BorderStyle.None;
            IngredientsGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            IngredientsGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            IngredientsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            IngredientsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            IngredientsGrid.DefaultCellStyle = dataGridViewCellStyle2;
            IngredientsGrid.EnableHeadersVisualStyles = false;
            IngredientsGrid.Location = new Point(6, 84);
            IngredientsGrid.Name = "IngredientsGrid";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            IngredientsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            IngredientsGrid.RowHeadersWidth = 62;
            IngredientsGrid.RowTemplate.Height = 40;
            IngredientsGrid.Size = new Size(812, 238);
            IngredientsGrid.TabIndex = 1;
            // 
            // RecipesCbx
            // 
            RecipesCbx.DropDownStyle = ComboBoxStyle.DropDownList;
            RecipesCbx.FlatStyle = FlatStyle.Flat;
            RecipesCbx.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RecipesCbx.FormattingEnabled = true;
            RecipesCbx.Location = new Point(6, 38);
            RecipesCbx.Name = "RecipesCbx";
            RecipesCbx.Size = new Size(812, 40);
            RecipesCbx.TabIndex = 0;
            RecipesCbx.SelectedIndexChanged += RecipesCbx_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(TotalFatLbl);
            groupBox2.Controls.Add(TotalProteinLbl);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(TotalCarbsLbl);
            groupBox2.Controls.Add(TotalCaloriesLbl);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(NutritionGrid);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.FlatStyle = FlatStyle.Flat;
            groupBox2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(3, 393);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(824, 400);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nutritional Breakdown";
            // 
            // TotalFatLbl
            // 
            TotalFatLbl.AutoSize = true;
            TotalFatLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalFatLbl.Location = new Point(690, 362);
            TotalFatLbl.Name = "TotalFatLbl";
            TotalFatLbl.Size = new Size(59, 32);
            TotalFatLbl.TabIndex = 8;
            TotalFatLbl.Text = "0.00";
            // 
            // TotalProteinLbl
            // 
            TotalProteinLbl.AutoSize = true;
            TotalProteinLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalProteinLbl.Location = new Point(690, 311);
            TotalProteinLbl.Name = "TotalProteinLbl";
            TotalProteinLbl.Size = new Size(59, 32);
            TotalProteinLbl.TabIndex = 7;
            TotalProteinLbl.Text = "0.00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(427, 362);
            label8.Name = "label8";
            label8.Size = new Size(107, 32);
            label8.TabIndex = 6;
            label8.Text = "Total Fat";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(427, 311);
            label7.Name = "label7";
            label7.Size = new Size(153, 32);
            label7.TabIndex = 5;
            label7.Text = "Total Protein";
            // 
            // TotalCarbsLbl
            // 
            TotalCarbsLbl.AutoSize = true;
            TotalCarbsLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalCarbsLbl.Location = new Point(252, 362);
            TotalCarbsLbl.Name = "TotalCarbsLbl";
            TotalCarbsLbl.Size = new Size(59, 32);
            TotalCarbsLbl.TabIndex = 4;
            TotalCarbsLbl.Text = "0.00";
            // 
            // TotalCaloriesLbl
            // 
            TotalCaloriesLbl.AutoSize = true;
            TotalCaloriesLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalCaloriesLbl.Location = new Point(252, 311);
            TotalCaloriesLbl.Name = "TotalCaloriesLbl";
            TotalCaloriesLbl.Size = new Size(59, 32);
            TotalCaloriesLbl.TabIndex = 3;
            TotalCaloriesLbl.Text = "0.00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(9, 362);
            label4.Name = "label4";
            label4.Size = new Size(135, 32);
            label4.TabIndex = 2;
            label4.Text = "Total Carbs";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(9, 311);
            label3.Name = "label3";
            label3.Size = new Size(160, 32);
            label3.TabIndex = 1;
            label3.Text = "Total Calories";
            // 
            // NutritionGrid
            // 
            NutritionGrid.AllowUserToResizeColumns = false;
            NutritionGrid.AllowUserToResizeRows = false;
            NutritionGrid.BorderStyle = BorderStyle.None;
            NutritionGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            NutritionGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            NutritionGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            NutritionGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            NutritionGrid.DefaultCellStyle = dataGridViewCellStyle5;
            NutritionGrid.EnableHeadersVisualStyles = false;
            NutritionGrid.Location = new Point(6, 38);
            NutritionGrid.Name = "NutritionGrid";
            NutritionGrid.RowHeadersWidth = 62;
            NutritionGrid.RowTemplate.Height = 40;
            NutritionGrid.Size = new Size(812, 257);
            NutritionGrid.TabIndex = 0;
            // 
            // ScrollPanel
            // 
            ScrollPanel.AutoScroll = true;
            ScrollPanel.Controls.Add(themedTabControl);
            ScrollPanel.Controls.Add(TableLayoutPanel);
            ScrollPanel.Location = new Point(13, 0);
            ScrollPanel.Name = "ScrollPanel";
            ScrollPanel.Size = new Size(869, 763);
            ScrollPanel.TabIndex = 1;
            // 
            // themedTabControl
            // 
            themedTabControl.Controls.Add(AIAdviceTab);
            themedTabControl.Controls.Add(ProjectionTab);
            themedTabControl.Dock = DockStyle.Bottom;
            themedTabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            themedTabControl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            themedTabControl.ItemSize = new Size(155, 42);
            themedTabControl.Location = new Point(0, 796);
            themedTabControl.Name = "themedTabControl";
            themedTabControl.SelectedIndex = 0;
            themedTabControl.Size = new Size(843, 369);
            themedTabControl.SizeMode = TabSizeMode.Fixed;
            themedTabControl.TabIndex = 1;
            // 
            // AIAdviceTab
            // 
            AIAdviceTab.BackColor = Color.FromArgb(240, 240, 240);
            AIAdviceTab.Controls.Add(AdviceTxt);
            AIAdviceTab.Controls.Add(GenerateAdviceBtn);
            AIAdviceTab.ForeColor = Color.Black;
            AIAdviceTab.Location = new Point(4, 46);
            AIAdviceTab.Name = "AIAdviceTab";
            AIAdviceTab.Padding = new Padding(3);
            AIAdviceTab.Size = new Size(835, 319);
            AIAdviceTab.TabIndex = 0;
            AIAdviceTab.Text = "AI Advice";
            // 
            // AdviceTxt
            // 
            AdviceTxt.BackColor = Color.FromArgb(45, 66, 91);
            AdviceTxt.BorderStyle = BorderStyle.None;
            AdviceTxt.Location = new Point(-5, 0);
            AdviceTxt.Name = "AdviceTxt";
            AdviceTxt.ReadOnly = true;
            AdviceTxt.Size = new Size(856, 236);
            AdviceTxt.TabIndex = 1;
            AdviceTxt.Text = "";
            // 
            // GenerateAdviceBtn
            // 
            GenerateAdviceBtn.BackColor = Color.FromArgb(0, 123, 255);
            GenerateAdviceBtn.FlatAppearance.BorderSize = 0;
            GenerateAdviceBtn.FlatStyle = FlatStyle.Flat;
            GenerateAdviceBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GenerateAdviceBtn.ForeColor = Color.White;
            GenerateAdviceBtn.Location = new Point(250, 242);
            GenerateAdviceBtn.Name = "GenerateAdviceBtn";
            GenerateAdviceBtn.Size = new Size(315, 59);
            GenerateAdviceBtn.TabIndex = 0;
            GenerateAdviceBtn.Text = "Generate Advice";
            GenerateAdviceBtn.UseVisualStyleBackColor = false;
            GenerateAdviceBtn.Click += GenerateAdviceBtn_Click;
            // 
            // ProjectionTab
            // 
            ProjectionTab.BackColor = Color.FromArgb(240, 240, 240);
            ProjectionTab.BackgroundImageLayout = ImageLayout.Center;
            ProjectionTab.Controls.Add(GenerateProjectionBtn);
            ProjectionTab.Controls.Add(pictureBox2);
            ProjectionTab.Controls.Add(pictureBox1);
            ProjectionTab.Controls.Add(label2);
            ProjectionTab.Controls.Add(label1);
            ProjectionTab.ForeColor = Color.Black;
            ProjectionTab.Location = new Point(4, 46);
            ProjectionTab.Name = "ProjectionTab";
            ProjectionTab.Padding = new Padding(3);
            ProjectionTab.Size = new Size(861, 319);
            ProjectionTab.TabIndex = 1;
            ProjectionTab.Text = "AI Projection";
            // 
            // GenerateProjectionBtn
            // 
            GenerateProjectionBtn.BackColor = Color.FromArgb(0, 123, 255);
            GenerateProjectionBtn.FlatAppearance.BorderSize = 0;
            GenerateProjectionBtn.FlatStyle = FlatStyle.Flat;
            GenerateProjectionBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GenerateProjectionBtn.ForeColor = Color.White;
            GenerateProjectionBtn.Location = new Point(7, 239);
            GenerateProjectionBtn.Name = "GenerateProjectionBtn";
            GenerateProjectionBtn.Size = new Size(242, 55);
            GenerateProjectionBtn.TabIndex = 4;
            GenerateProjectionBtn.Text = "Generate Projection";
            GenerateProjectionBtn.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.recipe_placeholder_image;
            pictureBox2.Location = new Point(552, 72);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(242, 222);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.recipe_placeholder_image;
            pictureBox1.Location = new Point(269, 72);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(242, 222);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(526, 17);
            label2.Name = "label2";
            label2.Size = new Size(289, 32);
            label2.TabIndex = 1;
            label2.Text = "If you don't follow Advice";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(290, 17);
            label1.Name = "label1";
            label1.Size = new Size(227, 32);
            label1.TabIndex = 0;
            label1.Text = "If you follow Advice";
            // 
            // HealthAnalysisForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 66, 91);
            ClientSize = new Size(880, 745);
            Controls.Add(ScrollPanel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "HealthAnalysisForm";
            Text = "HealthAnalysisForm";
            Load += HealthAnalysisForm_Load;
            TableLayoutPanel.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)IngredientsGrid).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NutritionGrid).EndInit();
            ScrollPanel.ResumeLayout(false);
            ScrollPanel.PerformLayout();
            themedTabControl.ResumeLayout(false);
            AIAdviceTab.ResumeLayout(false);
            ProjectionTab.ResumeLayout(false);
            ProjectionTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TableLayoutPanel;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView IngredientsGrid;
        private ComboBox RecipesCbx;
        private Button FetchNutritionInfoBtn;
        private DataGridView NutritionGrid;
        private Panel ScrollPanel;
        private Label label3;
        private Label label4;
        private Label TotalCaloriesLbl;
        private Label TotalFatLbl;
        private Label TotalProteinLbl;
        private Label label8;
        private Label label7;
        private Label TotalCarbsLbl;
        private ProgressBar NutritionProgressBar;
        private Services.ThemedTabControl themedTabControl;
        private TabPage AIAdviceTab;
        private RichTextBox AdviceTxt;
        private Button GenerateAdviceBtn;
        private TabPage ProjectionTab;
        private Button GenerateProjectionBtn;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
    }
}