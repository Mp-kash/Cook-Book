using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Weight { get; set; }
        public decimal KcalPer100g { get; set; }
        public decimal PricePer100g { get; set; }

        public Ingredient() { }
        public Ingredient(string name, string type, decimal weight, decimal kcal, decimal price, int? id = null)
        {
            Name = name;
            Type = type;
            Weight = weight;
            KcalPer100g = kcal;
            PricePer100g = price;
            if (id != null)
            {
                Id = (int)id;
            }
        }    
    }
}
