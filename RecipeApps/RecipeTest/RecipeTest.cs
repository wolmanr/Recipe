using System.Data;



namespace RecipeTest
{
    public class RecipeTest
    {
        [SetUp]

        public void Setup()
        {
            DBManager.SetConnectionString("Server=.\\SqlExpress;Database=RecipeDB;Trusted_Connection=True;Encrypt=false");
        }


        private int GetExistingRecipeId()
        {
            return SQLUtility.GetFirstColumnFirstRowValue("select top 1 recipeId from recipe");
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
            DataTable dt = SQLUtility.GetDataTable("SELECT TOP 1 RecipeId, RecipeName, Calories FROM Recipe WHERE CuisineId IS NULL");
            int recipeId = 0;
            string recipedezc = "";
            if (dt.Rows.Count > 0)
            {
                recipeId = (int)dt.Rows[0]["RecipeId"];
                recipedezc = dt.Rows[0]["Calories"] + " " + dt.Rows[0]["RecipeName"];
            }
            Assume.That(recipeId > 0, "No recipes with NULL CuisineId in DB, can't run test");
            TestContext.WriteLine("Found recipe with NULL CuisineId: ID = " + recipeId + ", Description = " + recipedezc);
            Recipe.Delete(dt);
            DataTable dtafterdelete = SQLUtility.GetDataTable("SELECT * FROM Recipe WHERE RecipeId = " + recipeId);
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
        [TestCase("Test Pancakes", 400, "2024-01-01", "2024-01-02")]

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

            r["cuisineId"] = cuisineId;
            r["Calories"] = maxcalories;
            r["RecipeName"] = recipename;
            r["CreatedDate"] = createddate;
            r["PublishedDate"] = publisheddate;
            Recipe.Save(dt);

            int newid = SQLUtility.GetFirstColumnFirstRowValue("select * from recipe where calories = " + maxcalories);
            Assert.IsTrue(newid > 0, "recipe with num of calories = " + maxcalories + "is not found in DB");
            TestContext.WriteLine("recipe with the num of calories " + maxcalories + " is found in DB with pk value = " + newid);

        }
    }
}

