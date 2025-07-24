using System.Data;
using Microsoft.Data.SqlClient;
using NUnit.Framework;



namespace RecipeTest
{
    public class RecipeTest
    {
        [SetUp]

        public void Setup()
        {
            DBManager.SetConnectionString("Server=tcp:recipe-wolmanr.database.windows.net,1433;Initial Catalog=RecipeDB;Persist Security Info=False;User ID=dev_recipeuser;Password=STArts234(&^;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");
        }


        private int GetExistingRecipeId()
        {
            return SQLUtility.GetFirstColumnFirstRowValue("select top 1 recipeId from recipe");
        }

        

        [Test]
        public void SearchRecipe()
        {
            string criteria = "o";
            int num = SQLUtility.GetFirstColumnFirstRowValue("select total = count(*) from recipe where recipename like '%" + criteria + "%'");
            Assume.That(num > 0, "can't run test, there are no recipes that match the search for " + criteria);
            TestContext.WriteLine("there are " + num + " recipes that match " + criteria);
            TestContext.Write("ensure that recipe search returns " + num + " rows");


            DataTable dt = Recipe.SearchRecipes(criteria);
            int results = dt.Rows.Count;

            Assert.IsTrue(results == num, "results of sproc does not match num of recipes, " + results + " is not equal to " + num);
            TestContext.WriteLine(" Number of rows returned by recipe search is " + results);

            Assert.IsTrue(results == num, "results of sproc does not match recipes, " + results + "is not equal to " + num);
            TestContext.WriteLine("num of rows returned by recipe search is " + results);

        }

        [Test]
        public void ChangeExisitingRecipeCalories()
        {
            GetExistingRecipeId();
            int recipeId = GetExistingRecipeId();
            Assume.That(recipeId > 0, "no recipes in DB, can't run tests");
            int Calories = SQLUtility.GetFirstColumnFirstRowValue("select Calories from recipe where recipeId = " + recipeId);
            TestContext.WriteLine("Caloreis for recipeId " + recipeId + " is " + Calories);
            Calories = Calories + 10;
            TestContext.WriteLine("Change Calories to " + Calories);
            DataTable dt = Recipe.Load(recipeId);

            dt.Rows[0]["Calories"] = Calories;
            Recipe.Save(dt);

            int newCalories = SQLUtility.GetFirstColumnFirstRowValue("select Calories from recipe where recipeId = " + recipeId);
            Assert.IsTrue(newCalories == Calories, "Num of Calories for recipe (" + recipeId + ") equals " + newCalories);
            TestContext.WriteLine("Calories for recipe (" + recipeId + ") = " + newCalories);
        }

        [Test]
        public void ChangeExisitingRecipeNameToBlank()
        {
            GetExistingRecipeId();
            int recipeId = GetExistingRecipeId();
            Assume.That(recipeId > 0, "no recipes in DB, can't run tests");
            string RecipeName = SQLUtility.GetFirstRowFirstColumnValueAsString("select RecipeName from recipe where recipeId = " + recipeId);
            TestContext.WriteLine("RecipeName for recipeId " + recipeId + " is " + RecipeName);
            RecipeName = " ";
            TestContext.WriteLine("Change RecipeName to " + RecipeName);
            DataTable dt = Recipe.Load(recipeId);

            dt.Rows[0]["RecipeName"] = RecipeName;
            Exception ex =  Assert.Throws<Exception>(()=>Recipe.Save(dt));
            TestContext.Write(ex.Message);
        }

        [Test]
        public void ChangeExisitingRecipeToInvalidRecipeName()
        {
            GetExistingRecipeId();
            int recipeId = GetExistingRecipeId();
            Assume.That(recipeId > 0, "no recipes in DB, can't run tests");
            string RecipeName = SQLUtility.GetFirstRowFirstColumnValueAsString("select RecipeName from recipe where recipeId = " + recipeId);
            TestContext.WriteLine("RecipeName for recipeId " + recipeId + " is " + RecipeName);
            RecipeName = " ";
            TestContext.WriteLine("Change RecipeName to " + RecipeName);
            DataTable dt = Recipe.Load(recipeId);

            dt.Rows[0]["RecipeName"] = RecipeName;
            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.Write(ex.Message);
        }

        [Test]
        public void DeleteRecipe()
        {
            string sql = @"
    select top 1 r.recipeid, r.recipename, r.Calories
    from recipe r
    left join RecipeIngredient ri on r.recipeid = ri.recipeid
    left join RecipeStep rs on r.recipeid = rs.recipeid
    where ri.recipeid is null
    and rs.recipeid is null;";

            DataTable dt = SQLUtility.GetDataTable(sql);
            int recipeId = 0;
            string recipedesc = "";
            if (dt.Rows.Count > 0)
            {
                recipeId = (int)dt.Rows[0]["RecipeId"];
                recipedesc = dt.Rows[0]["Calories"].ToString() + " " + dt.Rows[0]["RecipeName"].ToString();
            }

            Assume.That(recipeId > 0, "No deletable recipes found, can't run test");
            TestContext.WriteLine("Found deletable recipe: ID = " + recipeId + ", Description = " + recipedesc);

            Recipe.Delete(dt);

            DataTable dtafterdelete = SQLUtility.GetDataTable("select * from Recipe where RecipeId = " + recipeId);
            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "Record with RecipeId " + recipeId + " still exists in DB");
            TestContext.WriteLine("Record with RecipeId " + recipeId + " was successfully deleted.");
        }

        [Test]
        public void DeleteRecipeWithRecipeSteps()
        {
            string sql = @"
        select top 1 r.recipeid, r.recipename, r.calories
        from recipe r
        left join RecipeIngredient ri on r.recipeid = ri.recipeid
        left join RecipeStep rs on r.recipeid = rs.recipeid";

            DataTable dt = SQLUtility.GetDataTable(sql);
            int recipeId = 0;
            string recipedesc = "";
            if (dt.Rows.Count > 0)
            {
                recipeId = (int)dt.Rows[0]["RecipeId"];
                recipedesc = dt.Rows[0]["Calories"] + " " + dt.Rows[0]["RecipeName"];
            }

            Assume.That(recipeId > 0, "only deletable recipes found, can't run test");
            TestContext.WriteLine("Found un-deltable recipe: ID = " + recipeId + ", Description = " + recipedesc);

            Exception ex = Assert.Throws<Exception>(() => Recipe.Delete(dt));
            TestContext.Write(ex.Message);
        }

        [Test]
        public void DeleteRecipe_Fails_WhenRecentOrNotDraft()
        {
            string sql = @"
        select top 1 r.recipeid, r.recipename, r.calories
        from recipe r
        where 
            (r.archiveddate is not null and datediff(day, r.archiveddate, getdate()) < 30)
            or r.recipestatus <> 'draft'
            order by r.recipeid
";

            DataTable dt = SQLUtility.GetDataTable(sql);

            int recipeId = 0;
            string recipeDesc = "";
            if (dt.Rows.Count > 0)
            {
                recipeId = (int)dt.Rows[0]["RecipeId"];
                recipeDesc = dt.Rows[0]["Calories"] + " " + dt.Rows[0]["RecipeName"];
            }

            Assume.That(recipeId > 0, "No recipe found that is archived <30 days or not in draft, cannot run test.");

            TestContext.WriteLine($"Attempting to delete invalid recipe: ID = {recipeId}, Desc = {recipeDesc}");

            Exception ex = Assert.Throws<Exception>(() => Recipe.Delete(dt));
            TestContext.WriteLine("Delete attempt threw exception: " + ex.Message);

            StringAssert.Contains("cannot delete recipe", ex.Message.ToLower());
        }

        [Test]
        public static void TestDeleteRecipeWithoutMealOrCookbook()
        {
            string Sql = @"
        select top 1 r.RecipeID
        from Recipe r
        left join MealCourseRecipe mcr on r.RecipeID = mcr.RecipeId
        left join CookbookRecipe cr on r.RecipeID = cr.RecipeId
        where cr.CookbookRecipeId is NULL
          and mcr.RecipeId is null";

            DataTable dt = SQLUtility.GetDataTable(Sql);

            if (dt.Rows.Count == 0)
            {
                TestContext.WriteLine("No recipe found without meal or cookbook reference to delete.");
                return;
            }

            int recipeIdToDelete = (int)dt.Rows[0]["RecipeID"];
            TestContext.WriteLine($"Attempting to delete RecipeId = {recipeIdToDelete}");

            SqlCommand cmdDelete = SQLUtility.GetSqlCommand("RecipeDelete");
            SQLUtility.SetParamValue(cmdDelete, "@RecipeId", recipeIdToDelete);
            SQLUtility.ExecuteSQL(cmdDelete);

            string verifySql = $"select count(*) from Recipe where RecipeID = {recipeIdToDelete}";
            int countAfterDelete = SQLUtility.GetFirstColumnFirstRowValue(verifySql);

            if (countAfterDelete == 0)
            {
                TestContext.WriteLine("Delete succeeded, recipe no longer exists.");
            }
            else
            {
                TestContext.WriteLine("Delete failed, recipe still exists.");
            }
        }

        [Test]
        public void LoadRecipe()
        {
            int recipeId = GetExistingRecipeId();
            Assume.That(recipeId > 0, "no recipes in DB, can't run tests");
            TestContext.WriteLine("exisiting recipe with id = " + recipeId);
            TestContext.WriteLine("ensure that app loads recipe " + recipeId);
            DataTable dt = Recipe.Load(recipeId);
            int loadedId = (int)dt.Rows[0]["recipeId"];
            Assert.IsTrue(loadedId == recipeId, loadedId + " <> " + recipeId);
            TestContext.WriteLine("Loaded recipe (" + loadedId + ")");
        }

        [Test]
        public void GetCuisineList()
        {
            int cuisinecount = SQLUtility.GetFirstColumnFirstRowValue("select total = count(*) from cuisine");
            Assume.That(cuisinecount > 0, "No cuisne names in DB, can't test");
            DataTable dt = Recipe.GetCuisineList();
            TestContext.WriteLine("Num of cuisine name in DB = " + cuisinecount);
            TestContext.WriteLine("Ensure that number of rows returned by app matches " + cuisinecount);
            Assert.IsTrue(dt.Rows.Count == cuisinecount, "Num rows returned by app (" + dt.Rows.Count + ") <>" + cuisinecount);
            TestContext.WriteLine("Number of rows in cuisine table returned by the app = " + dt.Rows.Count);
        }
        [Test]
        [TestCase("Test Ice Coffee", 50)]
        public void InsertNewRecipe(string recipename, int calories)
        {
            DataTable dt = SQLUtility.GetDataTable("select * from recipe where recipeId = 0");
            DataRow r = dt.NewRow();
            dt.Rows.Add(r);

            int cuisineId = SQLUtility.GetFirstColumnFirstRowValue("select top 1 cuisineId from cuisine");
            Assume.That(cuisineId > 0, "cant run test, no cuisine name in the DB");

            int maxcalories = SQLUtility.GetFirstColumnFirstRowValue("select max(calories) from recipe") + 1;
            TestContext.WriteLine("insert recipe with calories = " + maxcalories);

            string uniqueRecipeName = $"{recipename} {DateTime.Now:yyyyMMdd_HHmmss}";
            r["cuisineId"] = cuisineId;
            r["Calories"] = maxcalories;
            r["RecipeName"] = uniqueRecipeName;

            // Do NOT set CreatedDate or PublishedDate, let the DB handle it

            Recipe.Save(dt);

            int newid = SQLUtility.GetFirstColumnFirstRowValue($"select top 1 recipeId from recipe where calories = {maxcalories}");
            Assert.IsTrue(newid > 0, "recipe with calories = " + maxcalories + " is not found in DB");

            TestContext.WriteLine($"recipe '{uniqueRecipeName}' with calories {maxcalories} found in DB with pk value = {newid}");
        }


        [Test]
        public void InsertRecipe_WithDuplicateRecipeName_ShouldThrowException()
        {
            DataTable dt = SQLUtility.GetDataTable("select * from recipe where recipeId = 0");
            DataRow r = dt.NewRow();
            dt.Rows.Add(r);

            string existingRecipeName = SQLUtility.GetFirstRowFirstColumnValueAsString("select top 1 RecipeName from recipe");
            Assume.That(!string.IsNullOrEmpty(existingRecipeName), "Cannot run test, no existing recipes in DB");

            int cuisineId = SQLUtility.GetFirstColumnFirstRowValue("select top 1 cuisineId from cuisine");
            Assume.That(cuisineId > 0, "Cannot run test, no cuisines in DB");

            r["cuisineId"] = cuisineId;
            r["Calories"] = 100;
            r["RecipeName"] = existingRecipeName;  
            r["CreatedDate"] = DateTime.Now;
            r["PublishedDate"] = DateTime.Now;

            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine("Exception message: " + ex.Message);

            Assert.That(ex.Message.ToLower().Contains("unique"), "Expected unique constraint violation error message");
        }
    }
}



