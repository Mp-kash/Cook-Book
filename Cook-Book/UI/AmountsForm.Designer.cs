namespace Cook_Book.UI
{
    partial class AmountsForm
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
            label1 = new Label();
            AmountNum = new NumericUpDown();
            OkBtn = new Button();
            CancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)AmountNum).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 31);
            label1.Name = "label1";
            label1.Size = new Size(167, 32);
            label1.TabIndex = 0;
            label1.Text = "Enter Amount:";
            // 
            // AmountNum
            // 
            AmountNum.Location = new Point(22, 116);
            AmountNum.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            AmountNum.Name = "AmountNum";
            AmountNum.Size = new Size(391, 39);
            AmountNum.TabIndex = 1;
            // 
            // OkBtn
            // 
            OkBtn.Location = new Point(22, 195);
            OkBtn.Name = "OkBtn";
            OkBtn.Size = new Size(196, 52);
            OkBtn.TabIndex = 2;
            OkBtn.Text = "Ok";
            OkBtn.UseVisualStyleBackColor = true;
            OkBtn.Click += OkBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(244, 195);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(169, 52);
            CancelBtn.TabIndex = 3;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // AmountsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 259);
            Controls.Add(CancelBtn);
            Controls.Add(OkBtn);
            Controls.Add(AmountNum);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "AmountsForm";
            Text = "AmountsForm";
            ((System.ComponentModel.ISupportInitialize)AmountNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown AmountNum;
        private Button OkBtn;
        private Button CancelBtn;
    }
}