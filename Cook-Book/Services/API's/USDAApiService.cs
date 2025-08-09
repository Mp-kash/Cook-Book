using System;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using DataAccessLayer.Logging;

namespace Cook_Book.Services.API_s
{
    public class USDAApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly JsonSerializerOptions _jsonOptions;

        public USDAApiService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        private void ErrorLogger(string message)
        {
            Logger.Log(message, DateTime.Now);
        }

        public async Task<FoodSearchResults> SearchFoodAsync(string query)
        {
            string url = $"https://api.nal.usda.gov/fdc/v1/foods/search?query={query}&api_key={_apiKey}";
            var response = await _httpClient.GetAsync(url);

            if(!response.IsSuccessStatusCode)
                return null;
            
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<FoodSearchResults>(content, _jsonOptions);
        }

        public async Task<NutrientInfo> GetNutrientInfoAsync(int fdcId)
        {
            string url = $"https://api.nal.usda.gov/fdc/v1/food/{fdcId}?api_key={_apiKey}";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<NutrientInfo>(content, _jsonOptions);
        }

        public async Task<IngredientNutritionInfo> GetIngredientNutriationAsync(string ingredientName)
        {
            try
            {
                // Search the ingredient to get the FDC ID
                var searchResults = await SearchFoodAsync(ingredientName);
                if (searchResults == null || searchResults.Foods == null || !searchResults.Foods.Any())
                    return null;

                var firstFood = searchResults.Foods.First(); // get first food result

                // get detailed nutritional info
                var nutrientInfo = await GetNutrientInfoAsync(firstFood.FdcId);
                if (nutrientInfo == null || nutrientInfo.FoodNutrients == null)
                    return null;

                decimal carbs = 0;
                decimal fat = 0;
                decimal calories = 0;

                // Use nutrients IDs for more reliable search
                foreach (var foodNutrient in nutrientInfo.FoodNutrients)
                {
                    if (foodNutrient.Nutrient == null || foodNutrient.Amount == 0)
                        continue;
                    switch (foodNutrient.Nutrient.Id)
                    {
                        case 1008: // Energy Kcal
                            calories = (decimal)foodNutrient.Amount;
                            break;
                        case 1005: // carbohydrates
                            carbs = (decimal)foodNutrient.Amount;
                            break;
                        case 1004: // total lipid (fat)
                            fat = (decimal)foodNutrient.Amount;
                            break;
                    }
                }

                return new IngredientNutritionInfo
                {
                    Ingredient = ingredientName,
                    Calories = calories,
                    Carbs = carbs,
                    Fat = fat,

                };
            }
            catch (Exception ex)
            {
                ErrorLogger($"Error fetching nutrition info for {ingredientName}: {ex.Message}");
                return null;
            }
        }
    }
}
