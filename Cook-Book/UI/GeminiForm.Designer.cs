namespace Cook_Book.UI
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            AdviceRichTxt = new RichTextBox();
            GeminiGroupBox = new GroupBox();
            tabPage2 = new TabPage();
            SaveImagesBtn = new Button();
            FailureLbl = new Label();
            SuccessLbl = new Label();
            FailureImageBox = new PictureBox();
            SuccessImageBox = new PictureBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FailureImageBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SuccessImageBox).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(891, 588);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(AdviceRichTxt);
            tabPage1.Controls.Add(GeminiGroupBox);
            tabPage1.Location = new Point(4, 41);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(883, 543);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "AI Advice";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // AdviceRichTxt
            // 
            AdviceRichTxt.Dock = DockStyle.Bottom;
            AdviceRichTxt.Location = new Point(3, 73);
            AdviceRichTxt.Name = "AdviceRichTxt";
            AdviceRichTxt.Size = new Size(877, 467);
            AdviceRichTxt.TabIndex = 1;
            AdviceRichTxt.Text = "";
            // 
            // GeminiGroupBox
            // 
            GeminiGroupBox.Location = new Point(0, 0);
            GeminiGroupBox.Name = "GeminiGroupBox";
            GeminiGroupBox.Size = new Size(887, 62);
            GeminiGroupBox.TabIndex = 0;
            GeminiGroupBox.TabStop = false;
            GeminiGroupBox.Text = "Gemini AI";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(SaveImagesBtn);
            tabPage2.Controls.Add(FailureLbl);
            tabPage2.Controls.Add(SuccessLbl);
            tabPage2.Controls.Add(FailureImageBox);
            tabPage2.Controls.Add(SuccessImageBox);
            tabPage2.Location = new Point(4, 41);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(883, 543);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "AI Projections";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // SaveImagesBtn
            // 
            SaveImagesBtn.Location = new Point(335, 482);
            SaveImagesBtn.Name = "SaveImagesBtn";
            SaveImagesBtn.Size = new Size(205, 53);
            SaveImagesBtn.TabIndex = 4;
            SaveImagesBtn.Text = "Save Images";
            SaveImagesBtn.UseVisualStyleBackColor = true;
            SaveImagesBtn.Click += SaveImagesBtn_Click;
            // 
            // FailureLbl
            // 
            FailureLbl.AutoSize = true;
            FailureLbl.Location = new Point(493, 14);
            FailureLbl.Name = "FailureLbl";
            FailureLbl.Size = new Size(186, 32);
            FailureLbl.TabIndex = 3;
            FailureLbl.Text = "Failure Scenario";
            // 
            // SuccessLbl
            // 
            SuccessLbl.AutoSize = true;
            SuccessLbl.Location = new Point(93, 14);
            SuccessLbl.Name = "SuccessLbl";
            SuccessLbl.Size = new Size(196, 32);
            SuccessLbl.TabIndex = 2;
            SuccessLbl.Text = "Success Scenario";
            // 
            // FailureImageBox
            // 
            FailureImageBox.Location = new Point(446, 72);
            FailureImageBox.Name = "FailureImageBox";
            FailureImageBox.Size = new Size(405, 405);
            FailureImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            FailureImageBox.TabIndex = 1;
            FailureImageBox.TabStop = false;
            // 
            // SuccessImageBox
            // 
            SuccessImageBox.Location = new Point(20, 72);
            SuccessImageBox.Name = "SuccessImageBox";
            SuccessImageBox.Size = new Size(405, 405);
            SuccessImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            SuccessImageBox.TabIndex = 0;
            SuccessImageBox.TabStop = false;
            // 
            // GeminiForm
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(891, 588);
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "GeminiForm";
            Text = "GeminiForm";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FailureImageBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)SuccessImageBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RichTextBox AdviceRichTxt;
        private GroupBox GeminiGroupBox;
        private Label FailureLbl;
        private Label SuccessLbl;
        private PictureBox FailureImageBox;
        private PictureBox SuccessImageBox;
        private Button SaveImagesBtn;
    }
}