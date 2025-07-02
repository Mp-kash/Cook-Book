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
    public class IngredientsTxtRepository :IIngredientsRepository
    {
        private readonly string _filePath;

        public event Action<string>? ErrorOccurred;

        private void OnErrorOccurred(string exMessage, string errorMessage)
        {
            ErrorOccurred?.Invoke(errorMessage);
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
                            string exMessage = "Error occurred while getting an ingredient from '.txt' file: " + ex.Message;
                            string message = "Error occurred while parsing ingredient data from the file.";
                            OnErrorOccurred(exMessage, message);
                            continue;
                        }
                    }
                }
            } catch (Exception ex)
            {
                string errorMessage = "Error occurred while getting ingredients from '.txt' file: " + ex.Message;
                string message = "Error occurred while reading ingredients from the file.";
                OnErrorOccurred(errorMessage, message);
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
                string message = "Error occurred while inserting ingredient into the file.";
                OnErrorOccurred(exMessage, message);
            }
            
        }

        public async Task UpdateIngredients(Ingredient ingredient)
        {
            try
            {
                List<Ingredient> ingredients = await GetIngredients();

                // Using LINQ expression to find ingredient to update
                Ingredient? ingredientToUpdate = ingredients.FirstOrDefault(i => i.Id == ingredient.Id);

                if (ingredientToUpdate == null)
                {
                    string exMessage = $"IngredientToUpdate with Id {ingredient.Id} not found!";
                    string message = $"Ingredient {ingredient.Name} not found.";
                    OnErrorOccurred(exMessage, message);
                }
                else
                {
                    // Update the original object instead of using new which creates a new object
                    ingredientToUpdate.Name = ingredient.Name;
                    ingredientToUpdate.Type = ingredient.Type;
                    ingredientToUpdate.Weight = ingredient.Weight;
                    ingredientToUpdate.KcalPer100g = ingredient.KcalPer100g;
                    ingredientToUpdate.PricePer100g = ingredient.PricePer100g;
                }

                // Write ingredients back to file
                WriteAllIngredients(ingredients);
            } 
            catch (Exception ex)
            {
                string exMessage = "Error occurred while updating ingredient in the .txt file: " + ex.Message;
                string message = "Error occurred while updating ingredient in the file.";
                OnErrorOccurred(exMessage, message);
            }
        }

        private void WriteAllIngredients(List<Ingredient> ingredients)
        {
            try
            {
                // Write a temporary file
                string tempFilePath = Path.GetTempFileName();

                using (StreamWriter sw = new StreamWriter(tempFilePath))
                {
                    ingredients.ForEach(async i =>
                    {
                        await sw.WriteLineAsync($"{i.Id}|{i.Name}|{i.Type}|{i.Weight}|{i.KcalPer100g}|{i.PricePer100g}");
                    });
                }

                // Delete the previous file and re-write it with the temp
                File.Delete(_filePath);
                File.Move(tempFilePath, _filePath);
            }
            catch (Exception ex)
            {
                string exMessage = "Error occurred while writing ingredients to '.txt' file: "+ex.Message;
                string message = "Error occurred while saving ingredients to the file.";
                OnErrorOccurred(exMessage, message);
            }
        }

        public async Task DeleteIngredients(Ingredient ingredient)
        {
            try
            {
                List<Ingredient> ingredients = await GetIngredients();

                Ingredient? ingredientToRemove = ingredients.FirstOrDefault(i => i.Id == ingredient.Id);

                if (ingredientToRemove == null)
                {
                    string exMessage = $"IngredientToRemove with Id {ingredient.Id} not found!";
                    string message = $"Ingredient {ingredient.Name} not found.";
                    OnErrorOccurred(exMessage, message);
                }
                else
                {
                    ingredients.Remove(ingredientToRemove);
                }

                // Write ingredients back to the file.
                WriteAllIngredients(ingredients);
            }
            catch(Exception ex)
            {
                string exMessage = "Error occurred while deleting ingredient from the .txt file: " + ex.Message;
                string message = "Error occurred while deleting ingredient from the file.";
                OnErrorOccurred(exMessage, message);
            }
        }
    }
}
