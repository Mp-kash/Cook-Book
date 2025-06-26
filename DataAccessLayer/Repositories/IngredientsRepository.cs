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

namespace DataAccessLayer.Repositories
{
    public class IngredientsRepository : IIngredientsRepository
    {
        public async Task<List<Ingredient>> GetIngredients(string? searchTxt = null)
        {
            string query = @"waitfor delay '00:00:00.700' 
                    select * from Fridge_Ingredients";
            if (!string.IsNullOrEmpty(searchTxt))
            {
                query += $"where name like '%{searchTxt}%'";
            }

            // Installed Microsoft.Data.SqlClient package which allows the app to connect to SqlServer
            using(IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
               // Added dapper in order to map the query results to C# object
                return (await connection.QueryAsync<Ingredient>(query)).ToList();
            }
        }

        public async Task InsertIngredients(Ingredient ingredient)
        {
            string query = @"waitfor delay '00:00:00.700' 
                insert into Fridge_Ingredients(Name, Type, Weight, KcalPer100g, PricePer100g) 
              values (@Name, @Type, @Weight, @KcalPer100g, @PricePer100g)";

            using(IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                await connection.ExecuteAsync(query, ingredient);
            }
        }
    }
}
