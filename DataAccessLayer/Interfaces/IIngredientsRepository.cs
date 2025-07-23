using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using DomainModels.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IIngredientsRepository
    {
        public event Action<string> ErrorOccurred;
        public event Action<string>? OnSuccess;
        public Task<List<Ingredient>> GetIngredients();
        public Task InsertIngredients(Ingredient ingredient);

        public Task UpdateIngredients(Ingredient ingredient);

        public Task DeleteIngredients(Ingredient ingredient);
        public Task UpdateAmounts(List<RecipeIngredient> recipeIngredients);
    }
}
