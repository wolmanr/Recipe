using System.Data;
using CPUFramework;
using Microsoft.Data.SqlClient;
namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable SearchRecipes(string recipename)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeGet");


            cmd.Parameters["@RecipeName"].Value = recipename;

            dt = SQLUtility.GetDataTable(cmd);

            return dt;
        }
        public static DataTable Load(int RecipeId)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeGet");
            cmd.Parameters["@RecipeId"].Value = RecipeId;
            dt = SQLUtility.GetDataTable(cmd);

            if (dt.Columns.Contains("RecipeId"))
            {
                dt.Columns["RecipeId"].ReadOnly = false;
                dt.Columns["RecipeId"].AllowDBNull = true;  // optional but helpful
            }

            return dt;
        }
        public static DataTable GetCuisineList()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = SQLUtility.GetSqlCommand("CuisineGet");
            cmd.Parameters["@All"].Value = 1;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetUserList()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = SQLUtility.GetSqlCommand("UserGet");
            cmd.Parameters["@All"].Value = 1;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }
        public static void Save(DataTable dtrecipe)
        {
            SQLUtility.DebugPrintDataTable(dtrecipe);
            DataRow r = dtrecipe.Rows[0];
            SqlCommand cmd;

            if ((int)r["RecipeId"] > 0)
            {
                cmd = SQLUtility.GetSqlCommand("recipeupdate");
                cmd.Parameters["@recipeid"].Value = r["RecipeId"];
            }
            else
            {
                cmd = SQLUtility.GetSqlCommand("recipeinsert");
                cmd.Parameters["@recipeid"].Direction = ParameterDirection.Output;
            }

            cmd.Parameters["@userid"].Value = r["UserId"];
            cmd.Parameters["@cuisineid"].Value = r["CuisineId"];
            cmd.Parameters["@recipename"].Value = r["RecipeName"];
            cmd.Parameters["@calories"].Value = r["Calories"];
            cmd.Parameters["@createddate"].Value = r["CreatedDate"];
            cmd.Parameters["@publisheddate"].Value = r["PublishedDate"];
            cmd.Parameters["@archiveddate"].Value = r["ArchivedDate"];

            SQLUtility.ExecuteSQL(cmd);

            if ((int)r["RecipeId"] == 0)
            {
                dtrecipe.Columns["RecipeId"].ReadOnly = false;
                r["RecipeId"] = cmd.Parameters["@recipeid"].Value;
            }
        }
        public static void Delete(DataTable dtrecipe)
        {
            int id = (int)dtrecipe.Rows[0]["RecipeId"];
            string sql = "delete recipe where recipeId = " + id;
            SQLUtility.ExecuteSQL(sql);
        }
    }
}
