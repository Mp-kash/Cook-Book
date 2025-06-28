using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Logging;
using DomainModels.Models;

namespace DataAccessLayer.Repositories
{
    public class IngredientsTxtRepository : IIngredientsRepository
    {
        private readonly string _filePath;
        private void OnErrorOccurred(string exMessage)
        {
            Logger.Log(exMessage, DateTime.Now);  
        }

        public IngredientsTxtRepository()
        {
            _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Ingredients.txt");

            if(!File.Exists(_filePath))
            {
                // Creates the file and immediately closes it.
                File.Create(_filePath).Dispose();
            }
        }


        public async Task<List<Ingredient>> GetIngredients()
        {
            List<Ingredient> ingredients = new();

            if(!File.Exists(_filePath)) 
                return ingredients;
            try
            {
                using (StreamReader sr = File.OpenText(_filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string? lines = await sr.ReadLineAsync();
                        string[] values = lines.Split('|');

                        try
                        {
                            Ingredient ingredient = new();
                            ingredient.Id = int.Parse(values[0]);
                            ingredient.Name = values[1];
                            ingredient.Type = values[2];
                            ingredient.Weight = decimal.Parse(values[3]);
                            ingredient.KcalPer100g = decimal.Parse(values[4]);
                            ingredient.PricePer100g = decimal.Parse(values[5]);

                            ingredients.Add(ingredient);
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
            } catch (Exception ex)
            {
                string message = "Error occurred while getting ingredients from '.txt' file: " + ex.Message;
                OnErrorOccurred(message);
            }
            return ingredients;
        }

        public async Task InsertIngredients(Ingredient ingredient)
        {
            int id = Guid.NewGuid().GetHashCode();
            try
            {
                using (StreamWriter sw = File.AppendText(_filePath))
                {
                    await sw.WriteLineAsync($"{id}|{ingredient.Name}|{ingredient.Type}|{ingredient.Weight}|{ingredient.KcalPer100g}|{ingredient.PricePer100g}");
                }
            }
            catch (Exception ex)
            {
                string exMessage = "Error occurred while inserting ingredients in '.txt' file: " + ex.Message;
                OnErrorOccurred(exMessage);
            }
            
        }

        
    }
}
