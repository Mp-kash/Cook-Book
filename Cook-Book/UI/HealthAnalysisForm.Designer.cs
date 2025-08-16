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
            tabControl1 = new TabControl();
            AIAdviceTab = new TabPage();
            GenerateAdviceBtn = new Button();
            AdviceTxt = new TextBox();
            ProjectionTab = new TabPage();
            GenerateProjectionsBtn = new Button();
            label2 = new Label();
            label1 = new Label();
            WithoutExercisePbx = new PictureBox();
            WithExercisePbx = new PictureBox();
            ScrollPanel = new Panel();
            TableLayoutPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IngredientsGrid).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NutritionGrid).BeginInit();
            tabControl1.SuspendLayout();
            AIAdviceTab.SuspendLayout();
            ProjectionTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)WithoutExercisePbx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WithExercisePbx).BeginInit();
            ScrollPanel.SuspendLayout();
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
            TableLayoutPanel.Controls.Add(tabControl1, 0, 2);
            TableLayoutPanel.Location = new Point(3, 3);
            TableLayoutPanel.Name = "TableLayoutPanel";
            TableLayoutPanel.RowCount = 3;
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 390F));
            TableLayoutPanel.RowStyles.Add(new RowStyle());
            TableLayoutPanel.RowStyles.Add(new RowStyle());
            TableLayoutPanel.Size = new Size(830, 1124);
            TableLayoutPanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(NutritionProgressBar);
            groupBox1.Controls.Add(FetchNutritionInfoBtn);
            groupBox1.Controls.Add(IngredientsGrid);
            groupBox1.Controls.Add(RecipesCbx);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(824, 384);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Recipe Ingredients";
            // 
            // NutritionProgressBar
            // 
            NutritionProgressBar.Location = new Point(179, 272);
            NutritionProgressBar.Name = "NutritionProgressBar";
            NutritionProgressBar.Size = new Size(423, 50);
            NutritionProgressBar.TabIndex = 3;
            // 
            // FetchNutritionInfoBtn
            // 
            FetchNutritionInfoBtn.Location = new Point(235, 328);
            FetchNutritionInfoBtn.Name = "FetchNutritionInfoBtn";
            FetchNutritionInfoBtn.Size = new Size(355, 51);
            FetchNutritionInfoBtn.TabIndex = 2;
            FetchNutritionInfoBtn.Text = "Fetch Nutrition Info";
            FetchNutritionInfoBtn.UseVisualStyleBackColor = true;
            FetchNutritionInfoBtn.Click += FetchNutritionInfoBtn_Click;
            // 
            // IngredientsGrid
            // 
            IngredientsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            IngredientsGrid.Location = new Point(9, 84);
            IngredientsGrid.Name = "IngredientsGrid";
            IngredientsGrid.RowHeadersWidth = 62;
            IngredientsGrid.Size = new Size(803, 238);
            IngredientsGrid.TabIndex = 1;
            // 
            // RecipesCbx
            // 
            RecipesCbx.DropDownStyle = ComboBoxStyle.DropDownList;
            RecipesCbx.FormattingEnabled = true;
            RecipesCbx.Location = new Point(9, 38);
            RecipesCbx.Name = "RecipesCbx";
            RecipesCbx.Size = new Size(803, 40);
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
            TotalFatLbl.Location = new Point(690, 362);
            TotalFatLbl.Name = "TotalFatLbl";
            TotalFatLbl.Size = new Size(58, 32);
            TotalFatLbl.TabIndex = 8;
            TotalFatLbl.Text = "0.00";
            // 
            // TotalProteinLbl
            // 
            TotalProteinLbl.AutoSize = true;
            TotalProteinLbl.Location = new Point(690, 311);
            TotalProteinLbl.Name = "TotalProteinLbl";
            TotalProteinLbl.Size = new Size(58, 32);
            TotalProteinLbl.TabIndex = 7;
            TotalProteinLbl.Text = "0.00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(427, 362);
            label8.Name = "label8";
            label8.Size = new Size(103, 32);
            label8.TabIndex = 6;
            label8.Text = "Total Fat";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(427, 311);
            label7.Name = "label7";
            label7.Size = new Size(148, 32);
            label7.TabIndex = 5;
            label7.Text = "Total Protein";
            // 
            // TotalCarbsLbl
            // 
            TotalCarbsLbl.AutoSize = true;
            TotalCarbsLbl.Location = new Point(252, 362);
            TotalCarbsLbl.Name = "TotalCarbsLbl";
            TotalCarbsLbl.Size = new Size(58, 32);
            TotalCarbsLbl.TabIndex = 4;
            TotalCarbsLbl.Text = "0.00";
            // 
            // TotalCaloriesLbl
            // 
            TotalCaloriesLbl.AutoSize = true;
            TotalCaloriesLbl.Location = new Point(252, 311);
            TotalCaloriesLbl.Name = "TotalCaloriesLbl";
            TotalCaloriesLbl.Size = new Size(58, 32);
            TotalCaloriesLbl.TabIndex = 3;
            TotalCaloriesLbl.Text = "0.00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 362);
            label4.Name = "label4";
            label4.Size = new Size(131, 32);
            label4.TabIndex = 2;
            label4.Text = "Total Carbs";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 311);
            label3.Name = "label3";
            label3.Size = new Size(156, 32);
            label3.TabIndex = 1;
            label3.Text = "Total Calories";
            // 
            // NutritionGrid
            // 
            NutritionGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            NutritionGrid.Location = new Point(9, 38);
            NutritionGrid.Name = "NutritionGrid";
            NutritionGrid.RowHeadersWidth = 62;
            NutritionGrid.Size = new Size(803, 257);
            NutritionGrid.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(AIAdviceTab);
            tabControl1.Controls.Add(ProjectionTab);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 799);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(824, 322);
            tabControl1.TabIndex = 2;
            // 
            // AIAdviceTab
            // 
            AIAdviceTab.Controls.Add(GenerateAdviceBtn);
            AIAdviceTab.Controls.Add(AdviceTxt);
            AIAdviceTab.Location = new Point(4, 41);
            AIAdviceTab.Name = "AIAdviceTab";
            AIAdviceTab.Padding = new Padding(3);
            AIAdviceTab.Size = new Size(816, 277);
            AIAdviceTab.TabIndex = 0;
            AIAdviceTab.Text = "AI Advice";
            AIAdviceTab.UseVisualStyleBackColor = true;
            // 
            // GenerateAdviceBtn
            // 
            GenerateAdviceBtn.Location = new Point(216, 217);
            GenerateAdviceBtn.Name = "GenerateAdviceBtn";
            GenerateAdviceBtn.Size = new Size(355, 54);
            GenerateAdviceBtn.TabIndex = 1;
            GenerateAdviceBtn.Text = "Generate Advice";
            GenerateAdviceBtn.UseVisualStyleBackColor = true;
            // 
            // AdviceTxt
            // 
            AdviceTxt.Location = new Point(5, 6);
            AdviceTxt.Multiline = true;
            AdviceTxt.Name = "AdviceTxt";
            AdviceTxt.ReadOnly = true;
            AdviceTxt.ScrollBars = ScrollBars.Vertical;
            AdviceTxt.Size = new Size(803, 205);
            AdviceTxt.TabIndex = 0;
            // 
            // ProjectionTab
            // 
            ProjectionTab.Controls.Add(GenerateProjectionsBtn);
            ProjectionTab.Controls.Add(label2);
            ProjectionTab.Controls.Add(label1);
            ProjectionTab.Controls.Add(WithoutExercisePbx);
            ProjectionTab.Controls.Add(WithExercisePbx);
            ProjectionTab.Location = new Point(4, 34);
            ProjectionTab.Name = "ProjectionTab";
            ProjectionTab.Padding = new Padding(3);
            ProjectionTab.Size = new Size(816, 284);
            ProjectionTab.TabIndex = 1;
            ProjectionTab.Text = "Projection";
            ProjectionTab.UseVisualStyleBackColor = true;
            // 
            // GenerateProjectionsBtn
            // 
            GenerateProjectionsBtn.Location = new Point(6, 218);
            GenerateProjectionsBtn.Name = "GenerateProjectionsBtn";
            GenerateProjectionsBtn.Size = new Size(274, 53);
            GenerateProjectionsBtn.TabIndex = 4;
            GenerateProjectionsBtn.Text = "Generate Projections";
            GenerateProjectionsBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(598, 14);
            label2.Name = "label2";
            label2.Size = new Size(191, 32);
            label2.TabIndex = 3;
            label2.Text = "Without Exercise";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(342, 14);
            label1.Name = "label1";
            label1.Size = new Size(155, 32);
            label1.TabIndex = 2;
            label1.Text = "With Exercise";
            // 
            // WithoutExercisePbx
            // 
            WithoutExercisePbx.Location = new Point(569, 61);
            WithoutExercisePbx.Name = "WithoutExercisePbx";
            WithoutExercisePbx.Size = new Size(239, 210);
            WithoutExercisePbx.TabIndex = 1;
            WithoutExercisePbx.TabStop = false;
            // 
            // WithExercisePbx
            // 
            WithExercisePbx.Location = new Point(316, 61);
            WithExercisePbx.Name = "WithExercisePbx";
            WithExercisePbx.Size = new Size(247, 210);
            WithExercisePbx.TabIndex = 0;
            WithExercisePbx.TabStop = false;
            // 
            // ScrollPanel
            // 
            ScrollPanel.AutoScroll = true;
            ScrollPanel.Controls.Add(TableLayoutPanel);
            ScrollPanel.Dock = DockStyle.Fill;
            ScrollPanel.Location = new Point(0, 0);
            ScrollPanel.Name = "ScrollPanel";
            ScrollPanel.Size = new Size(866, 750);
            ScrollPanel.TabIndex = 1;
            // 
            // HealthAnalysisForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(866, 750);
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
            tabControl1.ResumeLayout(false);
            AIAdviceTab.ResumeLayout(false);
            AIAdviceTab.PerformLayout();
            ProjectionTab.ResumeLayout(false);
            ProjectionTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)WithoutExercisePbx).EndInit();
            ((System.ComponentModel.ISupportInitialize)WithExercisePbx).EndInit();
            ScrollPanel.ResumeLayout(false);
            ScrollPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TableLayoutPanel;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TabControl tabControl1;
        private TabPage AIAdviceTab;
        private TabPage ProjectionTab;
        private DataGridView IngredientsGrid;
        private ComboBox RecipesCbx;
        private Button FetchNutritionInfoBtn;
        private DataGridView NutritionGrid;
        private TextBox AdviceTxt;
        private Button GenerateAdviceBtn;
        private Label label2;
        private Label label1;
        private PictureBox WithoutExercisePbx;
        private PictureBox WithExercisePbx;
        private Button GenerateProjectionsBtn;
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
    }
}