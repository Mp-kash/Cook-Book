namespace Nutrition_FitnessApp.UI
{
    partial class GeminiForm
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
            themedTabControl1 = new Nutrition_FitnessApp.Services.ThemedTabControl();
            AIAdvicePage = new TabPage();
            AdviceRichTxt = new RichTextBox();
            groupBox1 = new GroupBox();
            AIProjectionPage = new TabPage();
            FailureLbl = new Label();
            SuccessLbl = new Label();
            FailureImageBox = new PictureBox();
            SaveImagesBtn = new Button();
            SuccessImageBox = new PictureBox();
            themedTabControl1.SuspendLayout();
            AIAdvicePage.SuspendLayout();
            AIProjectionPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FailureImageBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SuccessImageBox).BeginInit();
            SuspendLayout();
            // 
            // themedTabControl1
            // 
            themedTabControl1.Controls.Add(AIAdvicePage);
            themedTabControl1.Controls.Add(AIProjectionPage);
            themedTabControl1.Dock = DockStyle.Fill;
            themedTabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            themedTabControl1.ItemSize = new Size(120, 40);
            themedTabControl1.Location = new Point(0, 0);
            themedTabControl1.Name = "themedTabControl1";
            themedTabControl1.SelectedIndex = 0;
            themedTabControl1.Size = new Size(891, 594);
            themedTabControl1.TabIndex = 0;
            // 
            // AIAdvicePage
            // 
            AIAdvicePage.BackColor = Color.FromArgb(240, 240, 240);
            AIAdvicePage.Controls.Add(AdviceRichTxt);
            AIAdvicePage.Controls.Add(groupBox1);
            AIAdvicePage.ForeColor = Color.Black;
            AIAdvicePage.Location = new Point(4, 44);
            AIAdvicePage.Name = "AIAdvicePage";
            AIAdvicePage.Padding = new Padding(3);
            AIAdvicePage.Size = new Size(883, 546);
            AIAdvicePage.TabIndex = 0;
            AIAdvicePage.Text = "AI Advice";
            // 
            // AdviceRichTxt
            // 
            AdviceRichTxt.Dock = DockStyle.Bottom;
            AdviceRichTxt.Location = new Point(3, 62);
            AdviceRichTxt.Name = "AdviceRichTxt";
            AdviceRichTxt.ScrollBars = RichTextBoxScrollBars.Vertical;
            AdviceRichTxt.Size = new Size(877, 481);
            AdviceRichTxt.TabIndex = 1;
            AdviceRichTxt.Text = "";
            // 
            // groupBox1
            // 
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(877, 60);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gemini AI";
            // 
            // AIProjectionPage
            // 
            AIProjectionPage.BackColor = Color.FromArgb(240, 240, 240);
            AIProjectionPage.Controls.Add(FailureLbl);
            AIProjectionPage.Controls.Add(SuccessLbl);
            AIProjectionPage.Controls.Add(FailureImageBox);
            AIProjectionPage.Controls.Add(SaveImagesBtn);
            AIProjectionPage.Controls.Add(SuccessImageBox);
            AIProjectionPage.ForeColor = Color.Black;
            AIProjectionPage.Location = new Point(4, 44);
            AIProjectionPage.Name = "AIProjectionPage";
            AIProjectionPage.Padding = new Padding(3);
            AIProjectionPage.Size = new Size(883, 546);
            AIProjectionPage.TabIndex = 1;
            AIProjectionPage.Text = "AI Projection";
            // 
            // FailureLbl
            // 
            FailureLbl.AutoSize = true;
            FailureLbl.BackColor = Color.Transparent;
            FailureLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            FailureLbl.Location = new Point(537, 25);
            FailureLbl.Name = "FailureLbl";
            FailureLbl.Size = new Size(188, 32);
            FailureLbl.TabIndex = 4;
            FailureLbl.Text = "Failure Scenario";
            // 
            // SuccessLbl
            // 
            SuccessLbl.AutoSize = true;
            SuccessLbl.BackColor = Color.Transparent;
            SuccessLbl.FlatStyle = FlatStyle.Flat;
            SuccessLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            SuccessLbl.Location = new Point(64, 25);
            SuccessLbl.Name = "SuccessLbl";
            SuccessLbl.Size = new Size(193, 32);
            SuccessLbl.TabIndex = 3;
            SuccessLbl.Text = "Success Scenario";
            // 
            // FailureImageBox
            // 
            FailureImageBox.Location = new Point(470, 78);
            FailureImageBox.Name = "FailureImageBox";
            FailureImageBox.Size = new Size(405, 405);
            FailureImageBox.TabIndex = 2;
            FailureImageBox.TabStop = false;
            // 
            // SaveImagesBtn
            // 
            SaveImagesBtn.FlatAppearance.BorderSize = 0;
            SaveImagesBtn.FlatStyle = FlatStyle.Flat;
            SaveImagesBtn.Location = new Point(352, 489);
            SaveImagesBtn.Name = "SaveImagesBtn";
            SaveImagesBtn.Size = new Size(176, 51);
            SaveImagesBtn.TabIndex = 1;
            SaveImagesBtn.Text = "Save Images";
            SaveImagesBtn.UseVisualStyleBackColor = true;
            SaveImagesBtn.Click += SaveImagesBtn_Click;
            // 
            // SuccessImageBox
            // 
            SuccessImageBox.Location = new Point(8, 78);
            SuccessImageBox.Name = "SuccessImageBox";
            SuccessImageBox.Size = new Size(405, 405);
            SuccessImageBox.TabIndex = 0;
            SuccessImageBox.TabStop = false;
            // 
            // GeminiForm
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(891, 594);
            Controls.Add(themedTabControl1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "GeminiForm";
            Text = "GeminiForm";
            themedTabControl1.ResumeLayout(false);
            AIAdvicePage.ResumeLayout(false);
            AIProjectionPage.ResumeLayout(false);
            AIProjectionPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FailureImageBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)SuccessImageBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Services.ThemedTabControl themedTabControl1;
        private TabPage AIAdvicePage;
        private GroupBox groupBox1;
        private TabPage AIProjectionPage;
        private RichTextBox AdviceRichTxt;
        private Label FailureLbl;
        private Label SuccessLbl;
        private PictureBox FailureImageBox;
        private Button SaveImagesBtn;
        private PictureBox SuccessImageBox;
    }
}