using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUFramework;
namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable SearchRecipes(string recipename)
        {
            string sql = "select r.recipeID, r.recipename, r.calories from recipe r where r.recipename like '%" + recipename + "%'";

            DataTable dt = SQLUtility.GetDataTable(sql);

            return dt;
        }
        public static DataTable Load(int RecipeId)
        {
            string sql = "select r.*, c.CuisineName from Recipe r join Cuisine c on r.CuisineId = c.CuisineId where r.RecipeID = " + RecipeId.ToString();
            return SQLUtility.GetDataTable(sql);

        }
        public static DataTable GetCuisineList()
        {
            return SQLUtility.GetDataTable("select CuisineId, CuisineName from Cuisine");
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
