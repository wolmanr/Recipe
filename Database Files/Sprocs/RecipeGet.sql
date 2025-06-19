CREATE OR ALTER PROCEDURE RecipeGet
    @RecipeId INT = 0,
    @All BIT = 0,
    @RecipeName VARCHAR(100) = NULL
AS
BEGIN
    -- Normalize empty string to NULL
    SET @RecipeName = NULLIF(@RecipeName, '')

    SELECT r.RecipeID, r.RecipeName, r.PictureRecipe, r.Calories
    FROM Recipe r
    WHERE (@All = 1)
       OR (@RecipeId > 0 AND r.RecipeID = @RecipeId)
       OR (@RecipeName IS NOT NULL AND r.RecipeName LIKE '%' + @RecipeName + '%')
END
go
/*
exec RecipeGet

exec RecipeGet @recipeId = 4, @all = 0

exec RecipeGet @All = 1

exec RecipeGet @RecipeName = ''

exec RecipeGet @RecipeName = 'b'

declare @recipeId int

select top 1 @recipeId = r.RecipeID from Recipe r

exec RecipeGet @recipeId = @recipeId
*/


