using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.CustomQueryResults
{
    public class RecipeIngredientWithNameAndAmount
    {
        public string Name { get; set; }
        public int IngredientId { get; set; }
        public decimal Amount { get; set; }

        // Constructor
        public RecipeIngredientWithNameAndAmount(string name, int ingredientId, decimal amount)
        {
            Name = name;
            IngredientId = ingredientId;
            Amount = amount;
        }
    }
}
