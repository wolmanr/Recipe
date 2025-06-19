using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string sql = "";
            int id = (int)r["RecipeId"];

            if (id > 0)
            {
                sql = string.Join(Environment.NewLine, $"update recipe set",
                    $" UserId = '{r["UserId"]}',",
                    $" CuisineId = '{r["CuisineId"]}',",
                    $" RecipeName = '{r["RecipeName"]}',",
                    $" Calories = {r["Calories"]},",
                    $" CreatedDate = '{r["CreatedDate"]}'",
                    $" where RecipeId = {r["RecipeId"]}");
            }
            else
            {
                sql = $"INSERT INTO Recipe (CuisineId, RecipeName, Calories, CreatedDate) " +
                $"SELECT '{r["CuisineId"]}', '{r["RecipeName"]}', '{r["Calories"]}', '{r["CreatedDate"]}'";
            }

            Debug.Print("--------------");
            Debug.Print(sql);
            SQLUtility.ExecuteSQL(sql);
        }
        public static void Delete(DataTable dtrecipe)
        {
            int id = (int)dtrecipe.Rows[0]["RecipeId"];
            string sql = "delete recipe where recipeId = " + id;
            SQLUtility.ExecuteSQL(sql);
        }
    }
}
