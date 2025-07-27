declare @recipeid int;

select top 1 @recipeid = r.RecipeID
from recipe r
left join MealCourseRecipe mcr on r.RecipeID = mcr.RecipeId
left join CookbookRecipe cr on r.RecipeID = cr.RecipeId;

select 'recipe' as TypeLabel, RecipeID as Id from recipe where RecipeID = @recipeid
union
select 'Meal', MealCourseID from MealCourseRecipe where RecipeId = @recipeid
union
select 'Cookbook', CookbookRecipeId from CookbookRecipe where RecipeId = @recipeid;

begin try
    begin tran;
        delete from mealcourserecipe where recipeId = @recipeid;
        delete from cookbookrecipe where recipeId = @recipeid;
        delete from Recipe where RecipeID = @recipeid;
    commit;
end try
begin catch
    rollback;
    throw;
end catch;

select 'recipe' as TypeLabel, RecipeID as Id from recipe where RecipeID = @recipeid
union
select 'Meal', MealCourseID from MealCourseRecipe where RecipeId = @recipeid
union
select 'Cookbook', CookbookRecipeId from CookbookRecipe where RecipeId = @recipeid;