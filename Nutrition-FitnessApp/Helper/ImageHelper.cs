using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cook_Book.Helper
{
    public class ImageHelper
    {
        public static Image placeHolderImage
        {
            get
            {
                var executingAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var imagePath = Path.Combine(executingAssemblyLocation, "Assets\\Images\\recipe_placeholder_image.png");
                return Image.FromFile(imagePath);
            }
        }

        // Convert Image to byte[] for DB
        public static byte[] ConvertToDbImage(string imagePath)
        {
            using (Image image = Image.FromFile(imagePath))
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png); // You can also use ImageFormat.Jpeg
                return ms.ToArray();
            }
        }

        // Convert byte[] from DB to Image
        public static Image ConvertFromDbImage(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
