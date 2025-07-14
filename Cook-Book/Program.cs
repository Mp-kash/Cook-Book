using System.Configuration;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cook_Book.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            ServiceCollection services = new ServiceCollection();

            // Register dependencies based on config
            if (ConfigurationManager.AppSettings["CurrentRepo"] == "txt")
                services.AddTransient<IIngredientsRepository, IngredientsTxtRepository>();
            else
                services.AddTransient<IIngredientsRepository, IngredientsRepository>();

            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IRecipeTypeRepository, RecipeTypeRepository>();
            services.AddTransient<IRecipeIngredientRepository, RecipeIngredientRepository>();

            // Register the form itself
            services.AddTransient<IngredientsForm>();
            services.AddTransient<RecipesForm>();
            services.AddTransient<RecipeTypeForm>();
            services.AddTransient<RecipeIngredientsForm>();
            services.AddTransient<AmountsForm>();

            // Build provider
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            // Get form from DI container
            var form = serviceProvider.GetRequiredService<RecipesForm>();

            Application.Run(form);
        }
    }
}