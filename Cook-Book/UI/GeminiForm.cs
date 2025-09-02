using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cook_Book.Helper;
using Cook_Book.Services;
using DataAccessLayer.Logging;
using Newtonsoft.Json.Linq;

namespace Cook_Book.UI
{
    public partial class GeminiForm : Form
    {
        private string _successImageBase64;
        private string _failureImageBase64;

        public GeminiForm(string advice, string successImage, string failureImage)
        {
            InitializeComponent();

            ShowForm();
            ApplyStyles(ThemeChanger.Instance.CurrentTheme);

            AdviceRichTxt.Text = advice;
            _successImageBase64 = successImage;
            _failureImageBase64 = failureImage;
            DisplayImages();
        }

        private void DisplayImages()
        {
            if (!string.IsNullOrEmpty(_successImageBase64))
            {
                var resizedSuccesImage = ImageUtils.Base64ToResizedImage(
                    _successImageBase64,
                    400,
                    400
                );

                if (resizedSuccesImage != null)
                {
                    SuccessImageBox.Image = resizedSuccesImage;
                    SuccessLbl.Text = "If you follow the advice";
                }
            }

            if (!string.IsNullOrEmpty(_failureImageBase64))
            {
                var resizedFailureImage = ImageUtils.Base64ToResizedImage(
                    _failureImageBase64,
                    400,
                    400
                );

                if (resizedFailureImage != null)
                {
                    FailureImageBox.Image = resizedFailureImage;
                    FailureLbl.Text = "If you don't follow the advice";
                }
            }
        }

        private void SaveImages()
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select folder to save the projections";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string timeStamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

                        if (SuccessImageBox.Image != null && SuccessImageBox.Image.Width > 0 && SuccessImageBox.Image.Height > 0)
                        {
                            string successPath = Path.Combine(folderDialog.SelectedPath, $"success_{timeStamp}.png");

                            SuccessImageBox.Image.Save(successPath, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        else if (FailureImageBox.Image != null && FailureImageBox.Image.Width > 0 && FailureImageBox.Image.Height > 0)
                        {
                            string failurePath = Path.Combine(folderDialog.SelectedPath, $"failure_{timeStamp}.png");

                            FailureImageBox.Image.Save(failurePath, System.Drawing.Imaging.ImageFormat.Png);
                        }

                        MessageBox.Show("Images saved successfully", "Success:");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.Log(ex.Message, DateTime.Now);
                    }
                }
            }            
        }

        private void SaveImagesBtn_Click(object sender, EventArgs e)
        {
            if (SuccessImageBox.Image == null || FailureImageBox.Image == null)
            {
                MessageBox.Show("No image displayed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                SaveImages();
        }

        private void ShowForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gemini AI";
        }

        private void ApplyStyles(int? theme = 1)
        {
            JObject themeConfig = themeConfigManager.LoadThemeConfig(theme);

            string primaryBgr = themeConfig["primaryBgr"]?.ToString() ?? "#FFFFFF";
            string secondaryBgr = themeConfig["secondaryBgr"]?.ToString() ?? "#F0F0F0";
            string primaryFgr = themeConfig["primaryFgr"]?.ToString() ?? "#000000";

            // buttons Bgr color
            string primaryBtnBgr = themeConfig["primaryBtnBgr"]?.ToString() ?? "#007BFF";
            string secondaryBtnBgr = themeConfig["secondaryBtnBgr"]?.ToString() ?? "#6C757D";
            string tertiaryBtnBgr = themeConfig["tertiaryBtnBgr"]?.ToString() ?? "#28A745";
            string classicBtnBgr = themeConfig["classicBtnBgr"]?.ToString() ?? "#DC3545";
            string disabledTertiaryBtnBgr = themeConfig["disabledTertiaryBtnBgr"]?.ToString() ?? "#d6c0ad";

            // buttons Fgr color
            string primaryBtnFgr = themeConfig["primaryBtnFgr"]?.ToString() ?? "#FFFFFF";
            string secondaryBtnFgr = themeConfig["secondaryBtnFgr"]?.ToString() ?? "#FFFFFF";
            string tertiaryBtnFgr = themeConfig["tertiaryBtnFgr"]?.ToString() ?? "#FFFFFF";
            string inputBgr = themeConfig["inputBgr"]?.ToString() ?? "#2b3b53";

            groupBox1.BackColor = ColorTranslator.FromHtml(primaryBgr);
            groupBox1.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);
            AdviceRichTxt.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            AdviceRichTxt.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);

            AIAdvicePage.BackColor = ColorTranslator.FromHtml(secondaryBgr);
            AIProjectionPage.BackColor = ColorTranslator.FromHtml(primaryBgr);

            SuccessLbl.ForeColor = ColorTranslator.FromHtml(primaryFgr);
            FailureLbl.ForeColor = ColorTranslator.FromHtml(primaryFgr);

            SaveImagesBtn.BackColor = ColorTranslator.FromHtml(classicBtnBgr);
            SaveImagesBtn.ForeColor = ColorTranslator.FromHtml(primaryBtnFgr);

            this.BackColor = ColorTranslator.FromHtml(secondaryBgr);
        }
    }
}
