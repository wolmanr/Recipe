--AS Amazing job, 100%
--Note: some of these scripts are needed for specific items, when the instructions say "specific" pick one item in your data and specify it in the where clause using a unique value that identifies it, do not use the primary key.
use recipeDB
--1) Sometimes when a staff member is fired. We need to eradicate everything from that user in our system. Write the SQL to delete a specific user and all the user's related records.
delete cr
from MealCourseRecipe cr
left join Recipe r
on r.RecipeID = cr.RecipeId 
left join Users u
on r.UserId = u.UserId
where u.UserName = 'johndoe'

delete cr
from MealCourseRecipe cr
left join MealCourse mc
on cr.MealCourseID = mc.MealCourseID
left join meal m
on mc.MealID = m.MealId
left join Users u
on m.UserId = u.UserId
where u.UserName = 'johndoe'

delete cr
from CookbookRecipe cr
left join cookbook c
on cr.CookbookId = c.CookbookId
left join Users u
on c.UserId = u.UserId
where u.UserName = 'johndoe'

delete mc
from MealCourse mc
left join meal m
on mc.MealID = m.MealId
left join Users u
on m.UserId = u.UserId
where u.UserName = 'johndoe'

delete ri
from RecipeIngredient ri
left join Recipe r
on ri.RecipeId = r.RecipeID
left join Users u
on r.UserId = u.UserId
where u.UserName = 'johndoe'

delete rs
from RecipeStep rs
left join Recipe r
on rs.RecipeId = r.RecipeID
left join Users u
on r.UserId = u.UserId
where u.UserName = 'johndoe'

delete m
from meal m
left join Users u
on m.UserId = u.UserId
where u.UserName = 'johndoe'

delete c
from Cookbook c
left join Users u
on c.UserId = u.UserId
where u.UserName = 'johndoe'

delete r
from Recipe r
left join Users u
on r.UserId = u.UserId
where u.UserName = 'johndoe'

delete u
from Users u
where u.UserName = 'johndoe'

--2) Sometimes we want to clone a recipe as a starting point and then edit it. For example we have a complex recipe (steps and ingredients) 
--and want to make a modified version. Write the SQL that clones a specific recipe, add " - clone" to its name.
declare @newrecipeids table (recipeid int);

insert into recipe (userid, cuisineid, recipename, calories, createddate, publisheddate, archiveddate)
output inserted.recipeid into @newrecipeids 
select r.userid, r.cuisineid, r.recipename + ' - clone', r.calories, '12/02/2023', '12/25/2023', null    
from recipe r
where r.recipename = 'Apple Yogurt Smoothie';

declare @newrecipeid int;
select top 1 @newrecipeid = recipeid from @newrecipeids;

insert into recipestep (recipeid, steporder, stepdescription)
select @newrecipeid, rs.steporder, rs.stepdescription
from recipestep rs
join recipe r on r.recipeid = rs.recipeid
where r.recipename = 'Apple Yogurt Smoothie';

insert into recipeingredient (recipeid, ingredientid, measurementid, amount, recipeingredientsequence)
select @newrecipeid, ri.ingredientid, ri.measurementid, ri.amount, ri.recipeingredientsequence
from recipeingredient ri
join recipe r on r.recipeid = ri.recipeid
where r.recipename = 'Apple Yogurt Smoothie';
/*

3) We offer users an option to auto-create a recipe book containing all of their recipes. 
Write a SQL script that creates the book for a specific user and fills it with their recipes.
The name of the book should be Recipes by Firstname Lastname. 
The price should be the number of recipes multiplied by $1.33
Sequence the book by recipe name.

Tip: To get a unique sequential number for each row in the result set use the ROW_NUMBER() function. See Microsoft Docs.
	 The following can be a column in your select statement: Sequence = ROW_NUMBER() over (order by colum name) , replace column name with the name of the column that the row number should be sorted
*/
-- Step 1: Declare the necessary variables
insert into dbo.Cookbook (UserId, CookbookName, Price, CookbookStatus, CreatedDate)
select 
    u.UserId, 
    concat('Recipes by ', u.FirstName, ' ', u.LastName), 
    count(r.RecipeId) * 1.33, 
    1, 
    '12/12/2021'
from dbo.Users u
join dbo.Recipe r on r.UserId = u.UserId
where u.UserName = 'Johndoe' 
group by u.UserId, u.FirstName, u.LastName;

declare @CookbookId int;
select @CookbookId = CookbookId 
from dbo.Cookbook 
where UserId = (select UserId from dbo.Users where UserName = 'Johndoe') 
  and CookbookName = concat('Recipes by ', (select FirstName from dbo.Users where UserName = 'Johndoe'), ' ', (select LastName from dbo.Users where UserName = 'Johndoe'));

;WITH RecipeList as (
    select 
        r.RecipeId, 
        RecipeSequence = row_number() over (order by r.RecipeName)
    from dbo.Recipe r
    where r.UserId = (select UserId from dbo.Users where UserName = 'Johndoe') 
)
insert into dbo.CookbookRecipe (CookbookId, RecipeId, CookbookRecipeSequence)
select @CookbookId, RecipeId, RecipeSequence
from RecipeList;




/*
4) Sometimes the calorie count of of an ingredient changes and we need to change the calorie total for all recipes that use that ingredient.
Our staff nutritionist will specify the amount to change per measurement type, and of course multiply the amount by the quantity of the ingredient.
For example, the calorie count for butter went down by 2 per ounce, and 10 per stick of butter. 
Write an update statement that changes the number of calories of a recipe for a specific ingredient. 
The statement should include at least two measurement types, like the example above. 
*/
update r
set r.Calories = r.Calories + 
                 (case 
                    when m.Measurement = 'tbsp' then ri.Amount * -2  
                    when m.Measurement = 'stick' then ri.Amount * -10 
                    else 0  
                  end)
from Recipe r
join RecipeIngredient ri 
  on r.RecipeId = ri.RecipeId
join Ingredient i
  on i.IngredientId = ri.IngredientId
join Measurement m
  on ri.MeasurementId = m.MeasurementId
where i.IngredientName = 'butter' 


/*
5) We need to send out alerts to users that have recipes sitting in draft longer the average amount of time that recipes have taken to be published.
Produce a result set that has 4 columns (Data values in brackets should be replaced with actual data)
	User First Name, 
	User Last Name, 
	email address (first initial + lastname@heartyhearth.com),
	Alert: 
		Your recipe [recipe name] is sitting in draft for [X] hours.
		That is [Z] hours more than the average [Y] hours all other recipes took to be published.
*/
;with RecipeDraftTimes as (
    select 
        r.RecipeId,
        r.UserId,
        r.RecipeName,
        TimeInDraft = datediff(hour, r.CreatedDate, GETDATE())
    from Recipe r
    where r.RecipeStatus = 'Draft'
),
AveragePublishedTime as (
    select AvgTimePublished = avg(datediff(hour, r.CreatedDate, r.PublishedDate))
    from Recipe r
    where r.PublishedDate is not null
)
select 
    u.FirstName, 
    u.LastName, 
    EmailAddress = concat(lower(substring(u.FirstName, 1, 1)), lower(u.LastName), '@heartyhearth.com'),
    Alert = concat(
        'Your recipe "', rdt.RecipeName, '" is sitting in draft for ', rdt.TimeInDraft, ' hours.',
        ' That is ', rdt.TimeInDraft - apt.AvgTimePublished, ' hours more than the average ', apt.AvgTimePublished, ' hours all other recipes took to be published.'
    )
from RecipeDraftTimes rdt
join Users u 
on u.UserId = rdt.UserId
cross join AveragePublishedTime apt
where rdt.TimeInDraft > apt.AvgTimePublished

/*
6) We want to send out marketing emails for books. Produce a result set with one row and one column "Email Body" as specified below.
The email should have a unique guid link to follow, which should be shown in the format specified. 

Email Body:
Order cookbooks from HeartyHearth.com! We have [X] books for sale, average price is [Y]. You can order them all and receive a 25% discount, for a total of [Z].
Click <a href = "www.heartyhearth.com/order/[GUID]">here</a> to order.
*/
select concat(
	'Order cookbooks from HeartyHearth.com! We have ',
	 count(c.CookbookId), ' books for sale, average price is ',
	  format(avg(c.Price), 'C', 'en-US'), ' You can order them all and receive a 25% discount, for a total of ', 
	  format(sum(c.Price)*.75, 'C', 'en-US'),
	 ' Click <a href = "www.heartyhearth.com/order/', 
	 Newid(), '">here</a> to order'
)
from Cookbook c

select EmailBody = concat(
'Order cookbooks from HeartyHearth.com! 
We have ', count(c.CookbookId), ' books for sale, average price is ', convert(decimal(7,2),avg(c.Price)), 
'. You can order them all and receive a 25% discount, for a total of ', convert(decimal(10,2),(sum(c.Price)*.75)), 
'. Click <a href = "www.heartyhearth.com/order/',newid(),'">here</a> to order.'
)
from Cookbook c 