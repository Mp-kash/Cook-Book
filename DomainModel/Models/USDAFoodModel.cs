using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Food
    {
        public int FdcId { get; set; }
        public string Description { get; set; }
    }

    public class FoodSearchResults
    {
        public List<Food> Foods { get; set; }
    }

    public class FoodNutrient
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("nutrient")]
        public Nutrient Nutrient { get; set; }  // This is the nested nutrient object

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }
    }

    public class Nutrient
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("unitName")]
        public string UnitName { get; set; }
    }

    public class NutrientInfo
    {
        public List<FoodNutrient> FoodNutrients { get; set; } 
    }
}
