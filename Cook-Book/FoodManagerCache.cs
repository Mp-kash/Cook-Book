using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private List<RecipeIngredientWithNameAndAmount> _recipeIngredientWithNameAndAmounts = new();

        public List<Recipe> AvailableRecipes = new();
        public List<Recipe> UnavilableRecipes = new();


        public FoodManagerCache(IRecipeIngredientRepository recipeIngredientRepository,IRecipeRepository recipeRepository,IIngredientsRepository ingredientsRepository)
        {
            _recipeIngredientRepository = recipeIngredientRepository;
            _recipeRepository = recipeRepository;
            _ingredientsRepository = ingredientsRepository;

            _ingredientsRepository.ErrorOccurred += message =>
              MessageBox.Show(message, "Error");
            _recipeRepository.ErrorOccurred += message =>
              MessageBox.Show(message, "Error");
            _recipeIngredientRepository.ErrorOccurred += message => MessageBox.Show(message, "Error");
        }

        public async Task RefreshData()
        {
            _ingredients = await _ingredientsRepository.GetIngredients();
            _recipes = await _recipeRepository.GetAllRecipes();
            _recipeIngredients = await _recipeIngredientRepository.GetAllRecipeIngredients();
            _recipeIngredientWithNameAndAmounts = await _recipeIngredientRepository.GetRecipeIngredients(0); // Assuming 0 is a placeholder for all recipes

            ClassifyRecipes();
        }

        public void ClassifyRecipes()
        {
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

                Recipe recipeToAdd = _recipes.FirstOrDefault(ri => ri.Id == recipeGroup.Key);
                if (isRecipeAvailable)
                    AvailableRecipes.Add(recipeToAdd);
                else
                    UnavilableRecipes.Add(recipeToAdd);
            }
        }
    }
}
