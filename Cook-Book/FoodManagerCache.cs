using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cook_Book.ViewModel;
using DataAccessLayer.CustomQueryResults;
using DataAccessLayer.Interfaces;
using DomainModel.Models;
using DomainModels.Models;

namespace Cook_Book
{
    public class FoodManagerCache
    {
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientsRepository _ingredientsRepository;

        private List<Ingredient> _ingredients = new();
        private List<Recipe> _recipes = new();
        private List<RecipeIngredient> _recipeIngredients = new();

        // Using a Dictionary
        private Dictionary<int, string> _ingredientIdToNameMapper = new();

        public List<Recipe> AvailableRecipes = new();
        public List<Recipe> UnavilableRecipes = new();


        public FoodManagerCache(IRecipeIngredientRepository recipeIngredientRepository,IRecipeRepository recipeRepository,IIngredientsRepository ingredientsRepository)
        {
            _recipeIngredientRepository = recipeIngredientRepository;
            _recipeRepository = recipeRepository;
            _ingredientsRepository = ingredientsRepository;

            _ingredientsRepository.ErrorOccurred += message =>
              MessageBox.Show(message, "Error");
            _ingredientsRepository.OnSuccess += message =>
              MessageBox.Show(message, "Success");
            _recipeRepository.ErrorOccurred += message =>
              MessageBox.Show(message, "Error");
            _recipeIngredientRepository.ErrorOccurred += message => MessageBox.Show(message, "Error");
        }

        public async Task RefreshData()
        {
            _ingredients = await _ingredientsRepository.GetIngredients();
            _ingredientIdToNameMapper = _ingredients.ToDictionary(i => i.Id, i => i.Name);

            _recipes = await _recipeRepository.GetAllRecipes();
            _recipeIngredients = await _recipeIngredientRepository.GetAllRecipeIngredients();

            ClassifyRecipes();
        }

        public void ClassifyRecipes()
        {
            AvailableRecipes.Clear();   // clear before adding
             UnavilableRecipes.Clear(); // clear before adding

            var groupedRecipesAndIngredients = _recipeIngredients.GroupBy(ri => ri.RecipeId).ToList();

            foreach(var recipeGroup in groupedRecipesAndIngredients)
            {
                int recipeId = recipeGroup.Key;
                bool isRecipeAvailable = true;
                foreach (var recipeIngredient in recipeGroup)
                {
                    Ingredient? fi = _ingredients.FirstOrDefault(i => i.Id == recipeIngredient.IngredientId);

                    if (fi == null || fi.Weight < recipeIngredient.Amount)
                    {
                        isRecipeAvailable = false;
                        break;
                    }
                }

                Recipe? recipeToAdd = _recipes.FirstOrDefault(ri => ri.Id == recipeGroup.Key);
                if (isRecipeAvailable)
                    AvailableRecipes.Add(recipeToAdd);
                else
                    UnavilableRecipes.Add(recipeToAdd);
            }
        }

        public List<RecipeIngredientExtendedVM> GetIngredients(int selectedRecipeId)
        {
            List<RecipeIngredientExtendedVM> ingredientsToReturn = new();

            var selectedRecipeIngredients = _recipeIngredients.GroupBy(ri => ri.RecipeId).FirstOrDefault(ri => ri.Key == selectedRecipeId);

            if (selectedRecipeIngredients == null)
                return ingredientsToReturn;

            foreach(var sri in selectedRecipeIngredients)
            {
                Ingredient? i = _ingredients.FirstOrDefault(i => i.Id == sri.IngredientId);

                decimal missingAmount = Math.Max(0, sri.Amount - i.Weight);

                ingredientsToReturn.Add(new RecipeIngredientExtendedVM(i.Name, i.Id, sri.Amount, missingAmount, i.KcalPer100g, i.PricePer100g));
            }
            return ingredientsToReturn;
        }

        public List<RecipeIngredientWithNameAndAmount> GetIngredientNameAndAmount(int selectedRecipeId)
        {
            List<RecipeIngredient> recipeIngredients = _recipeIngredients.Where(ri => ri.RecipeId == selectedRecipeId).ToList();

            var results = recipeIngredients
                .Select(ri =>
                {
                   _ingredientIdToNameMapper.TryGetValue(ri.IngredientId, out string name);
                   return new RecipeIngredientWithNameAndAmount(name ?? "Unknown", ri.IngredientId, ri.Amount);
                })
                .ToList();

            return results;
        }

        public async Task PrepareFood(int selectedRecipeId)
        {
            List<RecipeIngredient> recipeIngredients = _recipeIngredients.Where(ri => ri.RecipeId == selectedRecipeId).ToList();

            await _ingredientsRepository.UpdateAmounts(recipeIngredients);
        }
    }
}
