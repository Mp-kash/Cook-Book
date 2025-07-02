using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DomainModels.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using DataAccessLayer.Logging;

namespace DataAccessLayer.Repositories
{
    public class IngredientsRepository : IIngredientsRepository
    {
        public event Action<string>? ErrorOccurred;

        private void OnErrorOccurred(string exMessage, string errorMessage)
        {
            ErrorOccurred?.Invoke(errorMessage);
            Logger.Log(exMessage, DateTime.Now);
        }

        public async Task<List<Ingredient>> GetIngredients()
        {
            try
            {
                string query = @"waitfor delay '00:00:00.700' 
                    select * from Fridge_Ingredients";

                // Installed Microsoft.Data.SqlClient package which allows the app to connect to SqlServer
                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    // Added dapper in order to map the query results to C# object
                    return (await connection.QueryAsync<Ingredient>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                string exMessage = "An error occurred while getting ingredients from Sql Server: " + ex.Message;
                string message = "An error occurred while getting ingredients from the database.";
                OnErrorOccurred(exMessage, message);
                return new List<Ingredient>();
            }
        }

        public async Task InsertIngredients(Ingredient ingredient)
        {
            try
            {
                string query = @"waitfor delay '00:00:00.700' 
                insert into Fridge_Ingredients(Name, Type, Weight, KcalPer100g, PricePer100g) 
              values (@Name, @Type, @Weight, @KcalPer100g, @PricePer100g)";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, ingredient);
                }
            }
            catch(SqlException ex)
            {
                string exMessage = string.Empty;
                string message = string.Empty;

                // Unique constraint violation
                if (ex.Number == 2627) 
                {
                    exMessage = ex.Message;
                    message = "Ingredient with name already exist!";
                }
                else
                {
                    exMessage = "An error occurred in the sql server. " + ex.Message;
                    message = "An error occurred in the database.";
                }
                OnErrorOccurred(ex.Message, message);
            }
            catch (Exception ex)
            {
                
                string exMessage = "An error occurred while inserting ingredients into Sql Server: " + ex.Message;
                string message = "An error occurred while inserting ingredients to the database.";
                OnErrorOccurred(exMessage, message);
            }
        }

        public async Task UpdateIngredients(Ingredient ingredient)
        {
            try
            {
                string query = @"waitfor delay '00:00:00.700' 
                    update Fridge_Ingredients
                    set 
                    Name = @Name,
                    Type = @Type,
                    Weight = @Weight,
                    KcalPer100g = @KcalPer100g,
                    PricePer100g = @PricePer100g
                    where Id=@Id";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, ingredient);
                }
            }
            catch (Exception ex)
            {
                string exMessage = "An error occurred while updating ingredients in Sql Server: " + ex.Message;
                string message = "An error occurred while updating ingredients in the database.";
                OnErrorOccurred(exMessage, message);
            }
        }

        public async Task DeleteIngredients(Ingredient ingredient)
        {
            try
            {
                string query = @$"waitfor delay '00:00:00.450'
                    delete from Fridge_Ingredients
                    where id=@Id";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, ingredient);
                }
            }
            catch (Exception ex)
            {
                string exMessage = "An error occurred while deleting ingredients from Sql Server: " + ex.Message;
                string message = "An error occurred while deleting ingredients from the database.";
                OnErrorOccurred(exMessage, message);
            }
        }
    }
}
