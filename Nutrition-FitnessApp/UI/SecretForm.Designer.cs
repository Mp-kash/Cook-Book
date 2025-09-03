namespace Nutrition_FitnessApp.UI
{
    partial class SecretForm
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
            PreparedFoodCounter = new Label();
            SuspendLayout();
            // 
            // PreparedFoodCounter
            // 
            PreparedFoodCounter.AutoSize = true;
            PreparedFoodCounter.Location = new Point(12, 27);
            PreparedFoodCounter.Name = "PreparedFoodCounter";
            PreparedFoodCounter.Size = new Size(78, 32);
            PreparedFoodCounter.TabIndex = 0;
            PreparedFoodCounter.Text = "label1";
            // 
            // SecretForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(658, 398);
            Controls.Add(PreparedFoodCounter);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "SecretForm";
            Text = "SecretForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PreparedFoodCounter;
    }
}