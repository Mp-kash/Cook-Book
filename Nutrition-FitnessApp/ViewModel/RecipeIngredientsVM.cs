using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cook_Book.ViewModel
{
    public class RecipeIngredientsVM
    {
        public string Name { get; set; }
        public int IngredientId { get; set; }
        public decimal Amount { get; set; }
        public string NameWithAmount
        {
            get
            {
                return $"{Name}  {(int)Amount}g";
            }
        }

        public RecipeIngredientsVM(string name, int ingredientId, decimal amount)
        {
            Name = name;
            IngredientId = ingredientId;
            Amount = amount;
        }
    }
}
