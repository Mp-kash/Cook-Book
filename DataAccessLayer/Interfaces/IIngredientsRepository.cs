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
        public List<Ingredient> GetIngredients();
        public void InsertIngredients(Ingredient ingredient);
    }
}
