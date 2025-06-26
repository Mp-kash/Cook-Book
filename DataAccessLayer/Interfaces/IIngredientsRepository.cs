using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IIngredientsRepository
    {
        public Task<List<Ingredient>> GetIngredients(string? searchTxt = null);
        public Task InsertIngredients(Ingredient ingredient);
    }
}
