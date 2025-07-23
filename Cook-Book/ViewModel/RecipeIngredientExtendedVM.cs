using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cook_Book.ViewModel
{
    public class RecipeIngredientExtendedVM: RecipeIngredientsVM
    {
        public decimal MissingAmount { get; set; }
        public decimal KcalPer100g { get; set; }
        public decimal PricePer100g { get; set; }

        public string  NameWithMissingAmount 
        { 
            get
            {
                if (MissingAmount != 0)
                    return NameWithAmount + $"  Missing ({MissingAmount}g)";

                return NameWithAmount;
            }
        }

        public RecipeIngredientExtendedVM(string name, int ingredientId, decimal amount, decimal missingAmount, decimal kcalPer100g, decimal pricePer100g):base(name, ingredientId, amount) 
        {
            MissingAmount = missingAmount;
            KcalPer100g = kcalPer100g;
            PricePer100g = pricePer100g;
        }
    }
}
