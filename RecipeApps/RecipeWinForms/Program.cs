using CPUFramework;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace RecipeWinForms
 
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
            SQLUtility.connectionstring = "Server=.\\SQLExpress;Database=RecipeDB;Trusted_Connection=true;TrustServerCertificate=true";
            Application.Run(new FrmRecipeSearch());
        }
    }
}