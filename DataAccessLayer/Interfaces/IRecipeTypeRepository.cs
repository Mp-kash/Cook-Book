using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IRecipeTypeRepository
    {
        public event Action<string>? ErrorOccurred;
        public Task<List<RecipeType>> GetRecipeTypes();
        public Task InsertRecipeType(RecipeType recipeType);
        public Task DeleteRecipeType(RecipeType recipeType);
    }
}
