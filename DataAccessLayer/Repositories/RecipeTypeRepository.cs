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
    public class RecipeTypeRepository: IRecipeTypeRepository
    {
        public event Action<string>? ErrorOccurred;

        private void OnErrorOccurred(string errorMessage, string exMessage)
        {
            ErrorOccurred?.Invoke(errorMessage);
            Logger.Log(exMessage, DateTime.Now);
        }
        public async Task<List<RecipeType>> GetRecipeTypes()
        {
            try
            {
                string query = @"waitfor delay '00:00:00.300'
                    select * from RecipeTypes";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    return (await connection.QueryAsync<RecipeType>(query)).ToList();
                }
            }
            catch(Exception ex)
            {
                string message = "Error occurred while getting recipe types.";
                string exMessage = "Error occurred while getting recipe types from db " + ex.Message;
                OnErrorOccurred(message, exMessage);

                return new List<RecipeType>();
            }
            
        }

        public async Task InsertRecipeType(RecipeType recipeType)
        {
            try
            {
                string query = @"waitfor delay '00:00:00.300'
                    insert into RecipeTypes values(@Name)";
                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, recipeType);
                }
            }
            catch (Exception ex)
            {
                string message = "Error occurred while inserting recipe type.";
                string exMessage = "Error occurred while inserting recipe type in SqlServer. " + ex.Message;
                OnErrorOccurred(message, exMessage);
            }
        }

        public async Task DeleteRecipeType(RecipeType recipeType)
        {
            try
            {
                string query = @"waitfor delay '00:00:00.200'
                                delete from RecipeTypes
                                where id = @Id";

                using(IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query,recipeType);
                }
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 547)
            {
                // Foreign key violation, handle it specifically
                string message = "To delete this recipeType you have to delete the related Recipe(s) first.";
                string exMessage = "Deletion from SqlServer failed. " + sqlEx.Message;
                OnErrorOccurred(message, exMessage);
            }
            catch (Exception ex)
            {
                string message = "Error occurred while deleting recipe type.";
                string exMessage = "Error occurred while deleting recipe type in SqlServer. "+ex.Message;
                OnErrorOccurred(message, exMessage);
            }
            
        }

    }
}
