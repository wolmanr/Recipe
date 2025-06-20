﻿using System;
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
            string sql = "select r.*, c.CuisineName, u.username from Recipe r join Cuisine c on r.CuisineId = c.CuisineId join users u on r.userId = u.UserID where r.RecipeID = " + RecipeId.ToString();
            return SQLUtility.GetDataTable(sql);

        }
        public static DataTable GetCuisineList()
        {
            return SQLUtility.GetDataTable("select CuisineId, CuisineName from Cuisine");
        }

        public static DataTable GetUserList()
        {
            return SQLUtility.GetDataTable("select UserId, Username from users");
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
