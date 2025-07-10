create or alter procedure RecipeDelete(@recipeid int)
as 
begin 
    delete recipe where recipeId = @recipeid
end