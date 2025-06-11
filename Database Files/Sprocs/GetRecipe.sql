create or alter procedure GetRecipe(@RecipeId int = 0, @All bit = 0, @RecipeName varchar(100) = '')
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

exec GetRecipe

exec GetRecipe @recipeId = 4, @all = 0

exec GetRecipe @All = 1

exec GetRecipe @RecipeName = ''

exec GetRecipe @RecipeName = 'b'

declare @recipeId int

select top 1 @recipeId = r.RecipeID from Recipe r

exec GetRecipe @recipeId = @recipeId

