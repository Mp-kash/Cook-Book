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
using DataAccessLayer.Logging;

namespace Cook_Book.UI
{
    public partial class GeminiForm : Form
    {
        private string _successImageBase64;
        private string _failureImageBase64;

        public GeminiForm(string advice, string successImage, string failureImage)
        {
            InitializeComponent();
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

                        if (SuccessImageBox.Image != null)
                        {
                            string successPath = Path.Combine(folderDialog.SelectedPath, $"success_{timeStamp}.png");

                            SuccessImageBox.Image.Save(successPath, System.Drawing.Imaging.ImageFormat.Png);
                        }

                        if (FailureImageBox.Image != null)
                        {
                            string failurePath = Path.Combine(folderDialog.SelectedPath, $"failure_{timeStamp}.png");

                            FailureImageBox.Image.Save(failurePath, System.Drawing.Imaging.ImageFormat.Png);
                        }

                        MessageBox.Show("Images saved successfully", "Success:");
                    } catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.Log(ex.Message, DateTime.Now);
                    }
                }
            }
        }

        private void SaveImagesBtn_Click(object sender, EventArgs e)
        {
            SaveImages();
        }
    }
}
