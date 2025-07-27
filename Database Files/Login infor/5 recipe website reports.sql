--AS Good job! 100%
Use RecipeDB
/*
Our website development is underway! 
Below is the layout of the pages on our website, please provide the SQL to produce the necessary result sets.

Note: 
a) When the word 'specific' is used, pick one record (of the appropriate type, recipe, meal, etc.) for the query. 
    The way the website works is that a list of items are displayed and then the user picks one and navigates to the "details" page.
b) Whenever you have a record for a specific item include the name of the picture for that item. That is because the website will always show a picture of the item.
*/

/*
Home Page
    one result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
*/
select ItemName = 'Recipes', NumOfItem = count(*) from recipe r
union all select ItemName = 'Meals', NumOfItem = count(*) from meal m
union all select ItemName = 'Cookbooks', NumOfItem = count(*) from Cookbook c

/*
Recipe list page:
    List of all Recipes that are either published or archived, published recipes should appear at the top. Archived recipes should appear gray on the website.
	In order for the recipe name to be gray on the website, surround the archived recipe names with: <span style="color:gray">recipe name</span>
    In the resultset show the Recipe with its status, dates it was published and archived in mm/dd/yyyy format (blank if not archived), user, number of calories and number of ingredients.
    Tip: You'll need to use the convert function for the dates
*/

select RecipeName = 
    case 
        when r.RecipeStatus = 'Archived' then '<span style="color:gray">' + r.RecipeName + '</span>'
        else  r.RecipeName end, r.PictureRecipe,
r.RecipeStatus, PublishedDate = convert(varchar,r.PublishedDate,101), 
    ArchivedDate = ISNULL(CONVERT(varchar, r.ArchivedDate, 101), ''),
        u.UserName, r.Calories,  NumOfIngredients = (select count(*) from RecipeIngredient ri where r.RecipeID = ri.RecipeId)
from recipe r
join Users u
on r.UserId = u.UserId
where r.RecipeStatus in ('Published', 'Archived')
order by r.RecipeStatus desc

/*
Recipe details page:
    Show for a specific recipe (three result sets):
        a) Recipe header: recipe name, number of calories, number of ingredients and number of steps.
        b) List of ingredients: show the measurement quantity, measurement type and ingredient in one column, sorted by sequence. Ex. 1 Teaspoon Salt  
        c) List of prep steps sorted by sequence.
*/
select r.RecipeName, r.Calories,
NumOfIngredients = (select count(ri.RecipeIngredientId) from RecipeIngredient ri where r.RecipeID = ri.RecipeId),
NumOfSteps = (select count(rs.RecipeStepId) from RecipeStep rs where r.RecipeID = rs.RecipeId)
from Recipe r
where r.RecipeName = 'Chocolate Chip Cookies'

select ListOfIngredients =  concat(ri.Amount, ' ', m.Measurement, ' ', i.IngredientName), i.PictureIngredient
from Recipe r
join RecipeIngredient ri
on r.RecipeID = ri.RecipeId
join Ingredient i
on ri.IngredientId = i.IngredientId
join Measurement m
on ri.MeasurementId = m.MeasurementId
where r.RecipeName = 'Chocolate Chip Cookies'
order by ri.RecipeIngredientSequence

select rs.StepDescription
from recipeStep rs
join Recipe r
on r.RecipeID = rs.RecipeId
where r.RecipeName = 'Chocolate Chip Cookies'
order by rs.StepOrder

/*
Meal list page:
    For all active meals, show the meal name, user that created the meal, number of calories for the meal, number of courses, and number of recipes per each meal, sorted by name of meal
*/
select m.MealName, u.FirstName, u.LastName, NumOfCalories = COALESCE(sum(r.Calories),0), NumOfCourses = count(distinct mc.CourseID), NumOfRecipes = count(distinct r.RecipeID)
from  Users u 
left join meal m
on m.UserId = u.UserId
left join MealCourse mc 
on m.MealId = mc.MealId
left join MealCourseRecipe cr 
on mc.MealCourseId = cr.MealCourseId
left join Recipe r 
on cr.RecipeId = r.RecipeId
where m.MealStatus = 1
group by m.MealName, u.FirstName, u.LastName
order by m.MealName
--Missing the order by

/*
Meal details page:
    Show for a specific meal:
        a) Meal header: meal name, user, date created.
        b) List of all recipes: Result set should have one column, including the course type, whether the dish is serverd as main/side (if it's the main course), and recipe name. 
			Format for main course: CourseType: Main/Side dish - Recipe Name. 
            Format for non-main course: CourseType: Recipe Name
            Main dishes of the main course should be bold, using the bold tags as shown below
                ex: 
                    Appetizer: Mixed Greens
                    <b>Main: Main dish - onion Pastrami Chicken</b>
					Main: Side dish - Roasted cucumbers with mustard
*/
select m.MealName, m.PictureMeal, u.FirstName, u.LastName, m.CreatedDate
from meal m
join Users u
on m.UserId = u.UserId
where m.MealName = 'Breakfast Bash'

select 
    RecipeDetails = case
        when cr.IsMainDish = 1 then 
            c.CourseName + ': <b>Main dish - ' + r.RecipeName + '</b>'
        when cr.IsMainDish = 0 and c.CourseName = 'main course' then
            c.CourseName + ': Side dish - ' + r.RecipeName
        else c.CourseName + ': ' + r.RecipeName end
from 
Meal m
join 
MealCourse mc 
on m.MealId = mc.MealId
join 
MealCourseRecipe cr
on mc.MealCourseId = cr.MealCourseId
join 
Course c 
on mc.CourseId = c.CourseId
join Recipe r 
on cr.RecipeId = r.RecipeId
where m.MealName = 'Breakfast Bash';

/*
Cookbook list page:
    Show all active cookbooks with author and number of recipes per book. Sorted by book name.
*/
select c.CookbookName, u.FirstName, u.LastName, NumOfRecipes = count(cr.CookbookId)
from Cookbook c
join Users u
on c.UserId = u.UserId
join CookbookRecipe cr
on c.CookbookId = cr.CookbookId
where c.CookbookStatus = 1
group by c.CookbookName, u.FirstName, u.LastName
order by c.CookbookName

/*
Cookbook details page:
    Show for specific cookbook:
    a) Cookbook header: cookbook name, user, date created, price, number of recipes.
    b) List of all recipes in the correct order. Include recipe name, cuisine and number of ingredients and steps.  
        Note: User will click on recipe to see all ingredients and steps.
*/
select c.CookbookName, u.FirstName, u.LastName, c.CreatedDate, c.Price, NumOFRecipes = count(cr.RecipeId)
from Cookbook c
join Users u
on c.UserId = u.UserId
join CookbookRecipe cr
on c.CookbookId = cr.CookbookId
where c.CookbookName = 'Treats for two'
group by c.CookbookName, u.FirstName, u.LastName, c.CreatedDate, c.Price


select r.RecipeName, cu.CuisineName, NumOfIngredients = count(distinct ri.IngredientId), NumOfSteps = count(distinct rs.RecipeStepId)
from Cookbook c
join Users u
on c.UserId = u.UserId
join CookbookRecipe cr
on c.CookbookId = cr.CookbookId
join Recipe r
on cr.RecipeId = r.RecipeID
join Cuisine cu
on r.CuisineID = cu.CuisineId
left join RecipeIngredient ri
on r.RecipeID = ri.RecipeId
left join RecipeStep rs
on r.RecipeID = rs.RecipeId
where c.CookbookName = 'Treats for two'
group by r.RecipeName, cu.CuisineName
order by r.RecipeName

/*
April Fools Page:
    on April 1st we have a page with a joke cookbook. For that page provide the following.
    a) A list of all the recipes that are in all cookbooks. The recipe name should be the reverse of the real name with the first letter capitalized and all others lower case.
        There are matching pictures for those names, include the reversed picture names so that we can show the joke pictures.
        Note: ".jpg" file extension must be at the end of the reversed picture name EX: Recipe_Seikooc_pihc_etalocohc.jpg
    b) When the user clicks on any recipe they should see a spoof steps lists showing the step instructions for the LAST step of EACH recipe in the system. No sequence required.
        Hint: Use CTE
*/
select 
ReversedRecipe =  concat(
    upper(substring(reverse(r.RecipeName), 1, 1)), 
    lower(substring(reverse(r.RecipeName), 2, len(reverse(r.RecipeName)) - 1))),
ReversedPicture =  ConCAT('Recipe_', REPLACE(LOWER(REVERSE(r.RecipeName)), ' ', '_'), '.jpg'),
 c.CookbookName
from Cookbook c
join Users u
on c.UserId = u.UserId
join CookbookRecipe cr
on c.CookbookId = cr.CookbookId
join Recipe r
on cr.RecipeId = r.RecipeID

;with x as(
    select rs.StepOrder, r.RecipeID, rs.StepDescription,
     rn = ROW_NUMBER() OVER (PARTITIon BY rs.RecipeId ORDER BY rs.StepOrder DESC) 
    from Recipe r
    join RecipeStep rs
    on r.RecipeID = rs.RecipeId
)
select 
    r.RecipeName,
    LastStepDescription = x.StepDescription
from x
join Recipe r 
on x.RecipeId = r.RecipeID
where x.rn = 1;

/*
For site administration page:
5 seperate reports
    a) List of how many recipes each user created per status. Show 0 if user has no recipes at all.
    b) List of how many recipes each user created and average amount of days that it took for the user's recipes to be published.
    c) For each user, show three columns: Total number of meals, Total Active meals, Total Inactive meals. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    d) For each user, show three columns: Total number of cookbooks, Total Active cookbooks, Total Inactive cookbooks. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    e) List of archived recipes that were never published, and how long it took for them to be archived.
*/
select DraftRecipes = sum(case when r.RecipeStatus = 'Draft' then 1 else 0 end),
PublishedRecipes = sum(case when r.RecipeStatus = 'Published' then 1 else 0 end),
ArchivedRecipes = SUM(case when r.RecipeStatus = 'Archived' then 1 else 0 end),
u.UserName
from Users u
left join Recipe r
on u.UserId = r.UserId
group by u.UserName

select u.UserName, NumOfRecipes = count(r.RecipeId),
    AvgDaysToPublish = avg(datediff(day, r.CreatedDate, r.PublishedDate))
from Users u
join Recipe r 
on u.UserId = r.UserId
where r.RecipeStatus = 'Published' 
group by u.UserName
order by u.UserName;


select u.UserName, TotalNumOfMeals = count(m.MealId), 
TotalActiveMeals = sum(case when m.MealStatus = 1 then 1 else 0 end),
TotalInActiveMeals = sum(case when m.MealStatus = 0 then 1 else 0 end)
from Users u
join meal m
on u.UserId = m.UserId
group by u.UserName

select u.UserName,
TotalNumOfCookbooks = count(c.CookbookId),
TotalActiveCookbooks = sum(case when c.CookbookStatus = 1 then 1 else 0 end),
TotalInactivecookbooks = sum(case when c.CookbookStatus = 0 then 1 else 0 end)
from Users u
left join Cookbook c
on u.UserId = c.UserId
group by u.UserName

select r.RecipeName,
DaysTookToBeArchived = DateDiff(day, r.CreatedDate, r.ArchivedDate)
from Recipe r
where r.RecipeStatus = 'archived'
and r.PublishedDate is null

/*
For user dashboard page:
    a) For a specific user, show one result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
        Tip: If you would like, you can use a CTE to get the User Id once instead of in each union select*/
 ;with x as(
    select u.UserId, u.UserName
    from Users u
    where u.UserName = 'johndoe'
)
select ItemName = 'Recipe', NumOfRecipes = count(r.RecipeID)
from x
left join Recipe r
on x.UserId = r.UserId
union all select 'Meal', NumOfMeals = count(m.MealId)
from x
left join meal m
on x.UserId = m.UserId
union all select 'Cookbook', NumOfCookbooks = count(c.CookbookId)
from x
left join Cookbook c 
on c.UserId = x.UserId

 --   b) List of the user's recipes, display the status and the number of hours between the status it's in and the one before that. Omit recipes in drafted status.
select 
    u.UserName,                      
    r.RecipeName,                          
    r.RecipeStatus,               
    HoursBetweenStatuses = case 
        when r.RecipeStatus = 'Published' then 
            DATEDIFF(hour, 
                r.CreatedDate,          
                ISNULL(r.PublishedDate, r.CreatedDate))      
        WHEN r.RecipeStatus = 'Archived' THEN 
            DATEDIFF(hour, 
                ISNULL(r.PublishedDate, r.CreatedDate),          
                r.ArchivedDate) 
        else null                    
    end 
from Recipe r
join Users u 
on u.UserId = r.UserId  
where u.UserName = 'janesmith'      
and r.RecipeStatus <> 'Draft'   
order by r.RecipeId;

   /* OPTIonAL CHALLENGE QUESTIon
    c) Show a list of cuisines and the count of recipes the user has per cuisine, 0 if none
        Hint: Start by writing a CTE to give you cuisines for which the user does have recipes. */

;with x as (
    select DISTINCT c.CuisineId, c.CuisineName
    FROM Recipe r
    join Cuisine c 
    on r.CuisineID = c.CuisineID
    join Users u 
    on r.UserId = u.UserId
)
select 
    x.CuisineName,
    RecipeCount = COALESCE(COUNT(r.RecipeId), 0)  
from x
left join Recipe r 
on x.CuisineId = r.CuisineId
group by x.CuisineName;

