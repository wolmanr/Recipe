using CPUFramework;

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
            SQLUtility.connectionstring = "Server=tcp:recipe-wolmanr.database.windows.net,1433;Initial Catalog=RecipeDB;Persist Security Info=False;User ID=dev_recipeuser;Password=STArts234(&^;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;";
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmRecipeSearch());
        }
    }
}