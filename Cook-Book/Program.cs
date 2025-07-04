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

            // Register the form itself
            services.AddTransient<IngredientsForm>();

            // Build provider
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            // Get form from DI container
            var form = serviceProvider.GetRequiredService<IngredientsForm>();

            Application.Run(form);
        }
    }
}