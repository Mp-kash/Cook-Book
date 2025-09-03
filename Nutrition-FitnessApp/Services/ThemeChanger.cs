using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition_FitnessApp.Services
{
    public class ThemeChanger
    {
        private static readonly Lazy<ThemeChanger> _instance = new (() => new ThemeChanger());

        public static ThemeChanger Instance => _instance.Value;

        // Observer design pattern: (publisher)
        public event Action<int>? OnThemeChanged; 

        public int CurrentTheme { get; set; } = 1; // Default theme

        private ThemeChanger() { }
        
        public void ThemeChanged(int themeChanged)
        {
            var handler = OnThemeChanged;
            handler?.Invoke(themeChanged);
        }
    }
}
