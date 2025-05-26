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
            SQLUtility.connectionstring = "Server=.\\SQLExpress;Database=RecipeDB;Trusted_Connection=true;TrustServerCertificate=True";
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmRecipeSearch());
        }
    }
}