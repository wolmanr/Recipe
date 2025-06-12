create or alter procedure RecipeGet(@RecipeId int = 0, @All bit = 0, @RecipeName varchar(100) = '')
as
begin
    select @RecipeName = nullif(@RecipeName, '')
    select r.RecipeID, r.RecipeName, r.PictureRecipe, r.Calories, r.CreatedDate, r.PublishedDate, r.ArchivedDate, r.RecipeStatus
    from Recipe r
    where @RecipeId = r.RecipeID
    or @All = 1
    or r.RecipeName like '%' + @RecipeName + '%'
end 
go

exec RecipeGet

exec RecipeGet @recipeId = 4, @all = 0

exec RecipeGet @All = 1

exec RecipeGet @RecipeName = ''

exec RecipeGet @RecipeName = 'b'

declare @recipeId int

select top 1 @recipeId = r.RecipeID from Recipe r

exec RecipeGet @recipeId = @recipeId

