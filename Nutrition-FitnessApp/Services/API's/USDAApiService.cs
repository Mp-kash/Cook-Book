using System;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using DataAccessLayer.Logging;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Cook_Book.Services.API_s
{
    public class USDAApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly ConcurrentDictionary<string, IngredientNutritionInfo> _nutritionCache = new();

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
            if(_nutritionCache.TryGetValue(ingredientName, out var cachedInfo))
                return cachedInfo; 
            try 
            {
                var searchResults = await SearchFoodAsync(ingredientName);
                if (searchResults?.Foods?.Any() != true) return null;

                var firstFood = searchResults.Foods.First();
                var nutrientInfo = await GetNutrientInfoAsync(firstFood.FdcId);
                if (nutrientInfo?.FoodNutrients == null) return null;

                // Extract nutrients thru Id or Name as fallback
                ExtractNutrients(nutrientInfo.FoodNutrients, out decimal calories, out decimal carbs, out decimal fat, out decimal protein);

                var result = new IngredientNutritionInfo
                {
                    Ingredient = ingredientName,
                    Calories = calories,
                    Carbs = carbs,
                    Fat = fat,
                    Protein = protein
                };

                _nutritionCache.TryAdd(ingredientName, result);
                // After getting nutrientInfo:
                Debug.WriteLine($"Raw data for {ingredientName}: {JsonSerializer.Serialize(nutrientInfo)}");
                return result;
            }
            catch (Exception ex)
            {
                ErrorLogger($"Error fetching nutrition info for {ingredientName}: {ex.Message}");
                return null;
            }
        }

        private void ExtractNutrients(List<FoodNutrient> foodNutrients, out decimal calories, out decimal carbs, out decimal fat, out decimal protein)
        {
            calories = 0;
            carbs = 0;
            fat = 0;
            protein = 0;
            bool hasCalories = false;
            bool hasCarbs = false;
            bool hasFat = false;
            bool hasProtein = false;

            foreach (var fn in foodNutrients)
            {
                if(fn.Nutrient == null) continue;

                var value = fn.GetNormalizedValue();

                switch (fn.Nutrient.Id)
                {
                    case 1008: // Energy Kcal
                        calories = value;
                        hasCalories = true;
                        break;
                    case 1005: // carbohydrates
                        carbs = value;
                        hasCarbs = true;
                        break;
                    case 1004: // total lipid (fat)
                        fat = value;
                        hasFat = true;
                        break;
                    case 1003: // protein
                        protein = value;
                        hasProtein = true;
                        break;
                }
            }

            // fallback to name search if needed
            if(!hasCalories || !hasCarbs || !hasFat || !hasProtein)
            {
                foreach(var fn in foodNutrients)
                {
                    if (fn.Nutrient == null) continue;

                    if (!hasCalories && fn.Nutrient.Name.ToLower().Contains("energy"))
                    {
                        calories = fn.GetNormalizedValue();
                        hasCalories = true;
                    }
                    if (!hasCarbs && fn.Nutrient.Name.ToLower().Contains("carbohydrate"))
                    {
                        carbs = fn.GetNormalizedValue();
                        hasCarbs = true;
                    }
                    if (!hasFat && fn.Nutrient.Name.ToLower().Contains("fat") || fn.Nutrient.Name.ToLower().Contains("lipid"))
                    {
                        fat = fn.GetNormalizedValue();
                        hasFat = true;
                    }
                    if (!hasProtein && fn.Nutrient.Name.ToLower().Contains("protein"))
                    {
                        protein = fn.GetNormalizedValue();
                        hasProtein = true;
                    }
                    if (hasCalories && hasCarbs && hasFat && hasProtein)
                        break;
                }   
            }
        }
    }
}
