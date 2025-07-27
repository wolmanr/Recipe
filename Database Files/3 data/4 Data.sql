--  AS fantastic job! 98% see comments and resubmit.
use recipedb
go

delete from CookbookRecipe;
delete from Cookbook;
delete from MealCourseRecipe;
delete from MealCourse;
delete from Course;
delete from Meal;
delete from RecipeIngredient;
delete from Measurement;
delete from Ingredient;
delete from RecipeStep;
delete from Recipe;
delete from Cuisine;
delete from Users;
go

insert  Users(FirstName, LastName, UserName)
select 'jane', 'smith', 'janesmith'
union select 'john', 'doe', 'johndoe'
union select 'frank', 'slin', 'frankslin'
union select 'lary', 'grim', 'larygrim';
go

insert  Cuisine(CuisineName)
select 'american'
union select 'french'
union select 'english'
union select 'italian';
go

insert  dbo.Recipe(CuisineId, UserId, RecipeName, Calories, CreatedDate, PublishedDate, ArchivedDate)
select c.CuisineId, u.UserId, r.RecipeName, r.Calories, r.CreatedDate, r.PublishedDate, r.ArchivedDate
from
    (values 
        ('chocolate chip cookies', 100, '2005-07-01', '2005-11-25', null, 'american', 'janesmith'),
        ('apple yogurt smoothie', 50, '2019-04-18', '2019-07-21', '2023-09-21', 'french', 'janesmith'),
        ('cheese bread', 130, '2021-07-14', '2021-08-12', null, 'english', 'frankslin'),
        ('butter muffins', 60, '2022-11-27', '2023-01-14', '2024-01-01', 'american', 'larygrim'),
        ('chocolate cake', 100, '2005-07-01', null, null, 'american', 'johndoe')
    ) as r (RecipeName, Calories, CreatedDate, PublishedDate, ArchivedDate, CuisineName, UserName)
join dbo.Cuisine c on c.CuisineName = r.CuisineName
join dbo.Users u on u.UserName = r.UserName;
go

insert  RecipeStep(RecipeId, StepOrder, StepDescription)
select r.RecipeId, 1, 'first combine sugar, oil and eggs in a bowl' from Recipe r where r.RecipeName = 'chocolate chip cookies'
union select r.RecipeId, 2, 'mix well' from Recipe r where r.RecipeName = 'chocolate chip cookies'
union select r.RecipeId, 3, 'add flour, vanilla sugar, baking powder and baking soda' from Recipe r where r.RecipeName = 'chocolate chip cookies'
union select r.RecipeId, 4, 'beat for 5 minutes' from Recipe r where r.RecipeName = 'chocolate chip cookies'
union select r.RecipeId, 5, 'add chocolate chips' from Recipe r where r.RecipeName = 'chocolate chip cookies'
union select r.RecipeId, 6, 'freeze for 1-2 hours' from Recipe r where r.RecipeName = 'chocolate chip cookies'
union select r.RecipeId, 7, 'roll  balls and place spread out on a cookie sheet' from Recipe r where r.RecipeName = 'chocolate chip cookies'
union select r.RecipeId, 8, 'bake at 350 for 10 min' from Recipe r where r.RecipeName = 'chocolate chip cookies'

union select r.RecipeId, 1, 'peel the apples and dice' from Recipe r where r.RecipeName = 'apple yogurt smoothie'
union select r.RecipeId, 2, 'combine all ingredients in bowl except for apples and ice cubes' from Recipe r where r.RecipeName = 'apple yogurt smoothie'
union select r.RecipeId, 3, 'mix until smooth' from Recipe r where r.RecipeName = 'apple yogurt smoothie'
union select r.RecipeId, 4, 'add apples and ice cubes' from Recipe r where r.RecipeName = 'apple yogurt smoothie'
union select r.RecipeId, 5, 'pour  glasses' from Recipe r where r.RecipeName = 'apple yogurt smoothie'

union select r.RecipeId, 1, 'slit bread every 3/4 inch' from Recipe r where r.RecipeName = 'cheese bread'
union select r.RecipeId, 2, 'combine all ingredients in bowl' from Recipe r where r.RecipeName = 'cheese bread'
union select r.RecipeId, 3, 'fill slits with cheese mixture' from Recipe r where r.RecipeName = 'cheese bread'
union select r.RecipeId, 4, 'wrap bread in foil and bake for 30 minutes' from Recipe r where r.RecipeName = 'cheese bread'

union select r.RecipeId, 1, 'cream butter with sugars' from Recipe r where r.RecipeName = 'butter muffins'
union select r.RecipeId, 2, 'add eggs and mix well' from Recipe r where r.RecipeName = 'butter muffins'
union select r.RecipeId, 3, 'slowly add rest of ingredients and mix well' from Recipe r where r.RecipeName = 'butter muffins'
union select r.RecipeId, 4, 'fill muffin pans 3/4 full and bake for 30 minutes' from Recipe r where r.RecipeName = 'butter muffins';
go

insert  Ingredient(IngredientName)
select 'sugar'
union select 'oil'
union select 'eggs'
union select 'flour'
union select 'vanilla sugar'
union select 'baking powder'
union select 'baking soda'
union select 'chocolate chips'
union select 'granny smith apples'
union select 'vanilla yogurt'
union select 'orange juice'
union select 'honey'
union select 'ice cubes'
union select 'club bread'
union select 'butter'
union select 'shredded cheese'
union select 'garlic'
union select 'black pepper'
union select 'salt'
union select 'whipped cream cheese'
union select 'sour cream cheese'
union select 'vanilla pudding'
union select 'muffin pans';
go

insert  Measurement(Measurement)
select 'slice'
union select 'cup'
union select 'tsp'
union select 'tbsp'
union select 'oz'
union select 'clove'
union select 'pinch'
union select 'lb'
union select 'g'
union select 'ml';
go

insert  Meal(UserId, MealName, MealStatus, CreatedDate)
select u.UserId, 'breakfast bash', 1, '12/1/2021' from Users u where u.UserName = 'johndoe'
union select u.UserId, 'delicious dinner', 1, '01/24/2023' from Users u where u.UserName = 'frankslin'
union select u.UserId, 'lavish lunch', 1, '07/24/2023' from Users u where u.UserName = 'frankslin'
union select u.UserId, 'dairy dinner', 0, '01/13/2021' from Users u where u.UserName = 'johndoe'
union select u.UserId, 'meaty lunch', 1, '11/18/2023' from Users u where u.UserName = 'larygrim'
union select u.UserId, 'crunchy breakfast', 1, '05/18/2024' from Users u where u.UserName = 'janesmith';
go

insert  Course(CourseName, CourseOrder)
select 'appetizer', 1
union select 'main course', 2
union select 'dessert', 3;
go

insert  MealCourse(MealId, CourseId)
select (select m.MealId from Meal m where m.MealName = 'breakfast bash'), c.CourseId 
from Course c where c.CourseName in ('main course', 'appetizer')
union 
select (select m.MealId from Meal m where m.MealName = 'delicious dinner'), c.CourseId 
from Course c where c.CourseName in ('main course', 'appetizer', 'dessert')
union 
select (select m.MealId from Meal m where m.MealName = 'lavish lunch'), c.CourseId 
from Course c where c.CourseName in ('main course', 'appetizer', 'dessert');
go


insert  MealCourseRecipe (RecipeId, MealCourseID, IsMainDish)
select r.RecipeId, mc.MealCourseId, 1 
from Recipe r
join MealCourse mc 
    on mc.MealId = (select MealId from Meal where MealName = 'Breakfast Bash') 
    and mc.CourseId = (select CourseId from Course where CourseName = 'Main Course')
where r.RecipeName = 'Cheese Bread';

insert  MealCourseRecipe (RecipeId, MealCourseID, IsMainDish)
select r.RecipeId, mc.MealCourseId, 0 -- Side Dish
from Recipe r
join MealCourse mc 
    on mc.MealId = (select MealId from Meal where MealName = 'Breakfast Bash') 
    and mc.CourseId = (select CourseId from Course where CourseName = 'Main Course')
where r.RecipeName = 'Butter Muffins';

insert  MealCourseRecipe (RecipeId, MealCourseID, IsMainDish)
select r.RecipeId, mc.MealCourseId, 0 
from Recipe r
join MealCourse mc 
    on mc.MealId = (select MealId from Meal where MealName = 'Lavish Lunch') 
    and mc.CourseId = (select CourseId from Course where CourseName = 'Dessert')
where r.RecipeName = 'Chocolate Chip Cookies';

insert  MealCourseRecipe (RecipeId, MealCourseID, IsMainDish)
select r.RecipeId, mc.MealCourseId, 0
from Recipe r
join MealCourse mc 
    on mc.MealId = (select MealId from Meal where MealName = 'Breakfast Bash') 
    and mc.CourseId = (select CourseId from Course where CourseName = 'Appetizer')
where r.RecipeName = 'Apple Yogurt Smoothie';

insert  MealCourseRecipe (RecipeId, MealCourseID, IsMainDish)
select r.RecipeId, mc.MealCourseId, 1 -- Main Dish
from Recipe r
join MealCourse mc 
    on mc.MealId = (select MealId from Meal where MealName = 'Lavish Lunch') 
    and mc.CourseId = (select CourseId from Course where CourseName = 'Main Course')
where r.RecipeName = 'Cheese Bread';
go

insert  Cookbook(UserId, CookbookName, Price, CookbookStatus, CreatedDate)
select u.UserId, 'treats for two', 30, 1, '10/10/2022' from Users u where u.UserName = 'johndoe'
union select u.UserId, 'yummy food', 20, 0, '10/14/2023' from Users u where u.UserName = 'janesmith'
union select u.UserId, 'kids in the kitchen', 40, 1, '08/14/2020' from Users u where u.UserName = 'janesmith'
union select u.UserId, 'dinner done', 20, 0, '10/14/2023' from Users u where u.UserName = 'larygrim';
go

;with CookbookRecipeCTE as (
    select c.CookbookId, r.RecipeId,
    CookbookRecipeSequence = row_number() over (partition by c.CookbookId order by r.RecipeName) 
    from Cookbook c
    join Recipe r 
    on r.RecipeName in ('chocolate chip cookies', 'apple yogurt smoothie', 'cheese bread', 'butter muffins')
    where c.CookbookName in ('treats for two')

    union 
    select c.CookbookId, r.RecipeId,
    CookbookRecipeSequence = row_number() over (partition by c.CookbookId order by r.RecipeName) 
    from Cookbook c
    join Recipe r 
    on r.RecipeName in ('chocolate chip cookies', 'butter muffins')
    where c.CookbookName in ('yummy food')

    union 
    select c.CookbookId, r.RecipeId,
    CookbookRecipeSequence = row_number() over (partition by c.CookbookId order by r.RecipeName) 
    from Cookbook c
    join Recipe r 
    on r.RecipeName in ('cheese bread')
    where c.CookbookName in ('kids in the kitchen', 'dinner done')
)
insert  CookbookRecipe (CookbookId, RecipeId, CookbookRecipeSequence)
select CookbookId, RecipeId, CookbookRecipeSequence
from CookbookRecipeCTE;


insert into Recipe (CuisineId, UserId, RecipeName, Calories, CreatedDate, PublishedDate, ArchivedDate)
select top 1 
    CuisineId, 
    UserId, 
    'Test Recipe With Steps Only',
    250,
    getdate(),
    null,
    null
from
    Cuisine cross join Users;

insert into RecipeStep (RecipeId, StepOrder, StepDescription)
select 
    r.RecipeId,
    s.StepOrder,
    s.StepDescription
from
    (select top 1 RecipeId from Recipe where RecipeName = 'Test Recipe With Steps Only' order by RecipeId desc) r
cross join
    (values 
        (1, 'Step 1: Mix dry ingredients'),
        (2, 'Step 2: Add wet ingredients'),
        (3, 'Step 3: Bake at 350 degrees for 25 minutes')
    ) s(StepOrder, StepDescription);

insert into Recipe (CuisineId, UserId, RecipeName, Calories, CreatedDate, PublishedDate, ArchivedDate)
values (
    1,               -- Use an existing CuisineId from the Cuisine table
    2,               -- Existing UserId
    'Recent Archived Recipe',
    200,
    '2023-01-01',
    '2023-01-10',
    dateadd(day, -10, getdate())
);