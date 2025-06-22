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
            if (dtrecipe.Rows.Count == 0) return;

            DataRow r = dtrecipe.Rows[0];
            int id = (int)r["RecipeId"];

            if (id > 0)
            {
                SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeUpdate");

                cmd.Parameters["@recipeid"].Value = r["RecipeId"];
                cmd.Parameters["@userid"].Value = r["UserId"];
                cmd.Parameters["@cuisineid"].Value = r["CuisineId"];
                cmd.Parameters["@recipename"].Value = r["RecipeName"];
                cmd.Parameters["@calories"].Value = r["Calories"];
                cmd.Parameters["@createddate"].Value = r["CreatedDate"];
                cmd.Parameters["@publisheddate"].Value = r["PublishedDate"];
                cmd.Parameters["@archiveddate"].Value = r["ArchivedDate"];

                SQLUtility.ExecuteSQL(cmd);
            }
            else
            {
                string sql = $"insert into recipe (userid, cuisineid, recipename, calories, createddate) " +
                             $"select '{r["UserId"]}', '{r["CuisineId"]}', '{r["RecipeName"]}', '{r["Calories"]}', '{r["CreatedDate"]}'";

                SQLUtility.ExecuteSQL(sql);
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
