using System;
using System.Collections.Generic;
using System.Data;
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
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        public event Action<string>? ErrorOccurred;

        private void OnErrorOccurred(string errorMessage, string exMessage)
        {
            ErrorOccurred?.Invoke(errorMessage);
            Logger.Log(exMessage, DateTime.Now);
        }

        public async Task<List<RecipeIngredientWithNameAndAmount>> GetRecipeIngredients(int recipeId)
        {
            try
            {
                string query = $@"waitfor delay '00:00:00.300'
                        select i.Name, ri.IngredientId, ri.Amount
                        from RecipeIngredients as ri 
                        join Fridge_Ingredients as i
                        on ri.IngredientId = i.Id
                        where RecipeId={recipeId}";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    return (await connection.QueryAsync<RecipeIngredientWithNameAndAmount>(query)).ToList();

                }
            }
            catch (Exception ex)
            {
                string message = "Error occurred while getting recipe ingredients.";
                string exMessage = "Error occurred while getting recipe ingredients from SqlServer: " + ex.Message;
                OnErrorOccurred(message, exMessage);
                return new List<RecipeIngredientWithNameAndAmount>();
            }
        }

        public async Task InsertRecipeIngredint(RecipeIngredient recipeIngredient)
        {
            try
            {
                string query = @"waitfor delay '00:00:00.300'
                insert into RecipeIngredients(RecipeId, IngredientId, Amount) 
                values(@RecipeId, @IngredientId, @Amount)";
                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, recipeIngredient);
                }
            } catch (Exception ex)
            {
                string message = "Error occurred while inserting recipe ingredient.";
                string exMessage = "Error occurred while inserting recipe ingredient into SqlServer: " + ex.Message;
                OnErrorOccurred(message, exMessage);
            }
        }

        public async Task UpdateRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            try
            {
                string query = @"update RecipeIngredients
                        set amount = @Amount
                        where RecipeId = @RecipeId and IngredientId = @IngredientId";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, recipeIngredient); 
                }
            }
            catch(Exception ex)
            {
                string message = "Error occurred while updating recipe ingredient.";
                string exMessage = "Error occurred while updating recipe ingredient in SqlServer: " + ex.Message;
                OnErrorOccurred(message, exMessage);
            }
        }

        public async Task DeleteRecipeIngredient(int recipeId, int ingredientId)
        {
            try
            {
                string query = $@"waitfor delay '00:00:00.300'
                            delete from RecipeIngredients
                            where RecipeId = {recipeId} and IngredientId ={ingredientId}";
                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query);
                }
            }
            catch (Exception ex)
            {
                string message = "Error occurred while deleting recipe ingredient.";
                string exMessage = "Error occurred while deleting recipe ingredient from SqlServer: " + ex.Message;
                OnErrorOccurred(message, exMessage);
            }
        }

        public async Task<List<RecipeIngredient>> GetAllRecipeIngredients()
        {
            try
            {
                string query = $@"waitfor delay '00:00:00.300'
                        select * from RecipeIngredients";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    return (await connection.QueryAsync<RecipeIngredient>(query)).ToList();

                }
            }
            catch (Exception ex)
            {
                string message = "Error occurred while getting All recipe ingredients.";
                string exMessage = "Error occurred while getting All recipe ingredients from SqlServer: " + ex.Message;
                OnErrorOccurred(message, exMessage);
                return new List<RecipeIngredient>();
            }
        }
    }
}
