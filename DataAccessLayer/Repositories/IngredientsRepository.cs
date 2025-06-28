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

        private void OnErrorOccurred(string message)
        {
            Logger.Log(message, DateTime.Now);
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
                OnErrorOccurred(exMessage);
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
            } catch (Exception ex)
            {
                string exMessage = "An error occurred while inserting ingredients into Sql Server: " + ex.Message;
                OnErrorOccurred(exMessage);
            }
        }
    }
}
