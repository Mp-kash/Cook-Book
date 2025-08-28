namespace Cook_Book.UI
{
    partial class UserProfileForm
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            GenderTxt = new TextBox();
            AgeNumeric = new NumericUpDown();
            WeightNumeric = new NumericUpDown();
            GoalCbx = new ComboBox();
            ActivityCbx = new ComboBox();
            SubmitButton = new Button();
            label1 = new Label();
            HeightNumeric = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)AgeNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WeightNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HeightNumeric).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 230);
            label2.Name = "label2";
            label2.Size = new Size(72, 38);
            label2.TabIndex = 1;
            label2.Text = "Age:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 301);
            label3.Name = "label3";
            label3.Size = new Size(114, 38);
            label3.TabIndex = 2;
            label3.Text = "Gender:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(2, 377);
            label4.Name = "label4";
            label4.Size = new Size(186, 38);
            label4.TabIndex = 3;
            label4.Text = "Height in Cm:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(2, 460);
            label5.Name = "label5";
            label5.Size = new Size(182, 38);
            label5.TabIndex = 4;
            label5.Text = "Weight in Kg:";
            // 
            // GenderTxt
            // 
            GenderTxt.Location = new Point(143, 297);
            GenderTxt.Margin = new Padding(3, 4, 3, 4);
            GenderTxt.Name = "GenderTxt";
            GenderTxt.Size = new Size(402, 45);
            GenderTxt.TabIndex = 5;
            // 
            // AgeNumeric
            // 
            AgeNumeric.Location = new Point(143, 223);
            AgeNumeric.Margin = new Padding(3, 4, 3, 4);
            AgeNumeric.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            AgeNumeric.Name = "AgeNumeric";
            AgeNumeric.Size = new Size(402, 45);
            AgeNumeric.TabIndex = 6;
            // 
            // WeightNumeric
            // 
            WeightNumeric.Location = new Point(195, 458);
            WeightNumeric.Margin = new Padding(3, 4, 3, 4);
            WeightNumeric.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            WeightNumeric.Name = "WeightNumeric";
            WeightNumeric.Size = new Size(350, 45);
            WeightNumeric.TabIndex = 8;
            // 
            // GoalCbx
            // 
            GoalCbx.DropDownStyle = ComboBoxStyle.DropDownList;
            GoalCbx.FormattingEnabled = true;
            GoalCbx.Location = new Point(22, 83);
            GoalCbx.Margin = new Padding(3, 4, 3, 4);
            GoalCbx.Name = "GoalCbx";
            GoalCbx.Size = new Size(523, 46);
            GoalCbx.TabIndex = 9;
            // 
            // ActivityCbx
            // 
            ActivityCbx.DropDownStyle = ComboBoxStyle.DropDownList;
            ActivityCbx.FormattingEnabled = true;
            ActivityCbx.Location = new Point(22, 146);
            ActivityCbx.Margin = new Padding(3, 4, 3, 4);
            ActivityCbx.Name = "ActivityCbx";
            ActivityCbx.Size = new Size(523, 46);
            ActivityCbx.TabIndex = 10;
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(155, 521);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(301, 52);
            SubmitButton.TabIndex = 11;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(143, 9);
            label1.Name = "label1";
            label1.Size = new Size(219, 45);
            label1.TabIndex = 12;
            label1.Text = "Fill All Details";
            // 
            // HeightNumeric
            // 
            HeightNumeric.Location = new Point(195, 377);
            HeightNumeric.Margin = new Padding(3, 4, 3, 4);
            HeightNumeric.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            HeightNumeric.Name = "HeightNumeric";
            HeightNumeric.Size = new Size(350, 45);
            HeightNumeric.TabIndex = 13;
            // 
            // UserProfileForm
            // 
            AutoScaleDimensions = new SizeF(15F, 38F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 576);
            Controls.Add(HeightNumeric);
            Controls.Add(label1);
            Controls.Add(SubmitButton);
            Controls.Add(ActivityCbx);
            Controls.Add(GoalCbx);
            Controls.Add(WeightNumeric);
            Controls.Add(AgeNumeric);
            Controls.Add(GenderTxt);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "UserProfileForm";
            Text = "UserProfileForm";
            Load += UserProfileForm_Load;
            ((System.ComponentModel.ISupportInitialize)AgeNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)WeightNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)HeightNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox GenderTxt;
        private NumericUpDown AgeNumeric;
        private NumericUpDown WeightNumeric;
        private ComboBox GoalCbx;
        private ComboBox ActivityCbx;
        private Button SubmitButton;
        private Label label1;
        private NumericUpDown HeightNumeric;
    }
}