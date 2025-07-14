using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.CustomQueryResults;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Logging;
using DomainModel.Models;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Repositories
{
    public class RecipeRepository: IRecipeRepository
    {
        public event Action<string>? ErrorOccurred;
        private void OnErrorOccurred(string errorMessage, string exMessage)
        {
            ErrorOccurred?.Invoke(errorMessage);
            Logger.Log(exMessage, DateTime.Now);
        }

        public async Task<List<RecipesWithTypes>> GetRecipes() 
        {
            try
            {
                string query = @"waitfor delay '00:00:00.550'
                    select r.Id, r.Name, r.Description, r.Image, r.RecipeTypeId, rt.Name as 'Type'
                    from Recipes as r 
                    join RecipeTypes as rt on r.RecipeTypeId  = rt.Id ";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    return (await connection.QueryAsync<RecipesWithTypes>(query)).ToList();
                }
            }
            catch(Exception ex)
            {
                string message = "An error occured while inserting recipes in the db.";
                string exMessage = "An error occured while inserting recipes in SqlServer. " + ex.Message;
                OnErrorOccurred(message, exMessage);

                return new List<RecipesWithTypes>();
            }
            
        }

        public async Task InsertRecipes(Recipe recipe)
        {
            try
            {
                string query = @"waitfor delay '00:00:00.500'
                    insert into Recipes(Name, Description,Image, RecipeTypeId)
                              values(@Name, @Description,@Image, @RecipeTypeId)";

                using(IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, recipe);
                }
            }
            catch (Exception ex)
            {
                string message = "An error occured while inserting recipes in the db.";
                string exMessage = "An error occured while inserting recipes in SqlServer. "+ ex.Message;
                OnErrorOccurred(message, exMessage);
            }
            
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            try
            {
                string query = @"update Recipes
                    set Name = @Name,
                    Description = @Description,"
                    + (recipe.Image != null?  
                    "Image = @Image," : "" )+
                    @"RecipeTypeId = @RecipeTypeId
                    where Id = @Id";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, recipe);
                }
            }
            catch(Exception ex)
            {
                string message = "Error occured while editting recipes.";
                string exMessage = "Error occured while editting recipes in Sqlserver. " + ex.Message;
                OnErrorOccurred(message, exMessage);
            }
        }

        public void DeleteRecipe(int recipeId)
        {
            string query = @$"delete from Recipes
                where id = {recipeId}";

            using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                connection.Execute(query);
            }
        }
    }
}
