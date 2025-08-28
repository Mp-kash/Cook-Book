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
            GeminiAIGroupBox = new GroupBox();
            AdviceRichTxt = new RichTextBox();
            SuspendLayout();
            // 
            // GeminiAIGroupBox
            // 
            GeminiAIGroupBox.Dock = DockStyle.Top;
            GeminiAIGroupBox.Location = new Point(0, 0);
            GeminiAIGroupBox.Name = "GeminiAIGroupBox";
            GeminiAIGroupBox.Size = new Size(891, 69);
            GeminiAIGroupBox.TabIndex = 3;
            GeminiAIGroupBox.TabStop = false;
            GeminiAIGroupBox.Text = "Gemini AI";
            // 
            // AdviceRichTxt
            // 
            AdviceRichTxt.Dock = DockStyle.Bottom;
            AdviceRichTxt.Location = new Point(0, 75);
            AdviceRichTxt.MaxLength = 0;
            AdviceRichTxt.Name = "AdviceRichTxt";
            AdviceRichTxt.ReadOnly = true;
            AdviceRichTxt.ScrollBars = RichTextBoxScrollBars.Vertical;
            AdviceRichTxt.Size = new Size(891, 469);
            AdviceRichTxt.TabIndex = 4;
            AdviceRichTxt.Text = "";
            // 
            // GeminiForm
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(891, 544);
            Controls.Add(AdviceRichTxt);
            Controls.Add(GeminiAIGroupBox);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "GeminiForm";
            Text = "GeminiForm";
            ResumeLayout(false);
        }

        #endregion
        private GroupBox GeminiAIGroupBox;
        private RichTextBox AdviceRichTxt;
    }
}