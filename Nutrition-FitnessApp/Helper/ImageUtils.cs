using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Logging;

namespace Cook_Book.Helper
{
    public static class ImageUtils
    {

        public static event Action<string>? ImageError;

        private static void ErrorOccurred(string message, string exMessage)
        {
            ImageError?.Invoke(message);
            Logger.Log(exMessage, DateTime.Now);
        }

        //  Resizes an image to fit within specified dimensions while maintaining aspect ratio.

        public static Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            try
            {
                double ratioX = (double)maxWidth / image.Width;
                double rationY = (double)maxHeight / image.Height;
                double ratio = Math.Min(ratioX, rationY);

                int newWidth = (int)(image.Width * ratio);
                int newHeight = (int)(image.Height * ratio);

                // Creates new Bitmap with smooth rendering
                var newImage = new Bitmap(newWidth, newHeight);

                using(var graphics =  Graphics.FromImage(newImage))
                {
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.DrawImage (image, 0, 0, newWidth, newHeight);
                }

                return newImage;

            } catch(Exception ex)
            {
                ErrorOccurred(ex.Message, ex.Message);
                return image;
            }
        }

        // Resizes an image to fit within a square dimension
        public static Image ResizeImageSquare(Image image, int size)
        {
            return ResizeImage(image, size, size);
        }

        // Convert's Base64 string to Image and resizes it
        public static Image? Base64ToResizedImage(string base64String, int maxWidth, int maxHeight)
        {
            try
            {
                var image = Base64ToImage(base64String);
                return ResizeImage(image, maxWidth, maxHeight);

            } 
            catch(Exception ex)
            {
                ErrorOccurred(ex.Message, ex.Message);
                return null;
            }
        }

        // Converts base64 string to image
        public static Image? Base64ToImage(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using(var ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch(Exception ex)
            {
                ErrorOccurred(ex.Message, ex.Message);
                return null;
            }
        }

        public static string? ImageToBase64(Image image)
        {
            try
            {
                using(var ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
            catch (Exception ex)
            {
                ErrorOccurred(ex.Message, ex.Message);
                return null;
            }
        }
    }
}
