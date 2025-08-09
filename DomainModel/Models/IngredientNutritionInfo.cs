using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class IngredientNutritionInfo
    {
        public string Ingredient { get; set; }
        public decimal Calories { get; set; }
        public decimal Carbs { get; set; }
        public decimal Fat { get; set; }
        public decimal Protein { get; set; }
    }

    public class NutritionSummary
    {
        public decimal TotalCalories { get; set; }
        public decimal TotalCarbs { get; set; }
        public decimal TotalFat { get; set; }
        public decimal TotalProtein { get; set; }
        public List<IngredientNutritionInfo> Ingredients { get; set; } = new List<IngredientNutritionInfo>();
    }
}
