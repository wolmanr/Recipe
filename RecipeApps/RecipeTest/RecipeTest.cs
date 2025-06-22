using System.Data;
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
            TestContext.WriteLine("there are " + num + "recipes that match " + criteria);
            TestContext.Write("ensure that recipe search returns " + num + "rows");


            DataTable dt = Recipe.SearchRecipes(criteria);
            int results = dt.Rows.Count;

            Assert.IsTrue(results == num, "results of sproc does not match num of recipes, " + results + " is not equal to " + num);
            TestContext.WriteLine("Number of rows returned by recipe search is " + results);

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
        public void DeleteRecipe()
        {
            string sql = @"
        select top 1 r.recipeid, r.recipename, r.calories
        from recipe r
        left join cookbookrecipe cr on r.recipeid = cr.recipeid
        left join mealcourserecipe mcr on r.recipeid = mcr.recipeid
        where cr.recipeid is null
        and mcr.recipeid is null;";

            DataTable dt = SQLUtility.GetDataTable(sql);
            int recipeId = 0;
            string recipedesc = "";
            if (dt.Rows.Count > 0)
            {
                recipeId = (int)dt.Rows[0]["RecipeId"];
                recipedesc = dt.Rows[0]["Calories"] + " " + dt.Rows[0]["RecipeName"];
            }

            Assume.That(recipeId > 0, "No deletable recipes found, can't run test");
            TestContext.WriteLine("Found deletable recipe: ID = " + recipeId + ", Description = " + recipedesc);

            Recipe.Delete(dt);

            DataTable dtafterdelete = SQLUtility.GetDataTable("select * from Recipe where RecipeId = " + recipeId);
            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "Record with RecipeId " + recipeId + " still exists in DB");
            TestContext.WriteLine("Record with RecipeId " + recipeId + " was successfully deleted.");
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
        [TestCase("Test Ice Cofee", 50, "2024-01-01", "2024-01-02")]

        public void InsertNewRecipe(string recipename, int calories, DateTime createddate, DateTime publisheddate)
        {
            DataTable dt = SQLUtility.GetDataTable("select * from recipe where recipeId = 0");
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);
            int cuisineId = SQLUtility.GetFirstColumnFirstRowValue("select top 1 cuisineId from cuisine");
            Assume.That(cuisineId > 0, "cant run test, no cuisine name in the DB");
            int maxcalories = SQLUtility.GetFirstColumnFirstRowValue("select max (calories) from recipe");

            maxcalories = maxcalories + 1;

            TestContext.WriteLine("insert recipe with calories = " + maxcalories);
            string uniqueRecipeName = $"{recipename} {DateTime.Now:yyyyMMdd_HHmmss}";
            r["cuisineId"] = cuisineId;
            r["Calories"] = maxcalories;
            r["RecipeName"] = uniqueRecipeName;
            r["CreatedDate"] = createddate;
            r["PublishedDate"] = publisheddate;
            Recipe.Save(dt);

            int newid = SQLUtility.GetFirstColumnFirstRowValue("select * from recipe where calories = " + maxcalories);
            Assert.IsTrue(newid > 0, "recipe with num of calories = " + maxcalories + "is not found in DB");
            TestContext.WriteLine("recipe" + uniqueRecipeName + "with the num of calories " + maxcalories + " is found in DB with pk value = " + newid);

        }
    }
}

