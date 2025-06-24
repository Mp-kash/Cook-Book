using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

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

            IIngredientsRepository ingredientsRepo = new IngredientsRepository();

            Application.Run(new IngredientsForm(ingredientsRepo));
        }
    }
}