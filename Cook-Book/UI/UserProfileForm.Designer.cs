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
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            SubmitButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
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
            label4.Location = new Point(23, 377);
            label4.Name = "label4";
            label4.Size = new Size(106, 38);
            label4.TabIndex = 3;
            label4.Text = "Height:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 460);
            label5.Name = "label5";
            label5.Size = new Size(111, 38);
            label5.TabIndex = 4;
            label5.Text = "Weight:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(143, 297);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(351, 45);
            textBox1.TabIndex = 5;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(143, 223);
            numericUpDown1.Margin = new Padding(3, 4, 3, 4);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(352, 45);
            numericUpDown1.TabIndex = 6;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(143, 377);
            numericUpDown2.Margin = new Padding(3, 4, 3, 4);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(352, 45);
            numericUpDown2.TabIndex = 7;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(143, 460);
            numericUpDown3.Margin = new Padding(3, 4, 3, 4);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(352, 45);
            numericUpDown3.TabIndex = 8;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(22, 83);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(472, 46);
            comboBox1.TabIndex = 9;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(22, 146);
            comboBox2.Margin = new Padding(3, 4, 3, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(472, 46);
            comboBox2.TabIndex = 10;
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(155, 521);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(273, 52);
            SubmitButton.TabIndex = 11;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
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
            // UserProfileForm
            // 
            AutoScaleDimensions = new SizeF(15F, 38F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 576);
            Controls.Add(label1);
            Controls.Add(SubmitButton);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 5, 5, 5);
            Name = "UserProfileForm";
            Text = "UserProfileForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button SubmitButton;
        private Label label1;
    }
}