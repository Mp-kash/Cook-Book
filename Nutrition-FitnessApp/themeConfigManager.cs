using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cook_Book.Services;
using Newtonsoft.Json.Linq;

namespace Nutrition_FitnessApp
{
    public static class themeConfigManager
    {
        // installed newtonsoft.json NuGet package for JSON handling
        public static JObject LoadThemeConfig(int? theme = 1)
        {
            string themePath;

            if (theme == 2)
                themePath = "themeConfig2.json";
            else
                themePath = "themeConfig.json";

            if (File.Exists(themePath))
            {
                string jsonContent = File.ReadAllText(themePath);
                return JObject.Parse(jsonContent);
            }
            else
            {
                return null;
            }
        }
    }
}
