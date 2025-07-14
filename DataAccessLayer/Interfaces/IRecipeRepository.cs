using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.CustomQueryResults;
using DomainModel.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IRecipeRepository
    {
        public event Action<string>? ErrorOccurred;
        public Task<List<RecipesWithTypes>> GetRecipes();
        public Task InsertRecipes(Recipe recipe);
        public Task UpdateRecipe(Recipe recipe);
        public void DeleteRecipe(int recipeId);
    }
}
