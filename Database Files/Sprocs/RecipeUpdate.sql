create or alter procedure dbo.RecipeUpdate
(
    @RecipeID int output,
    @CuisineID int,
    @UserId int,
    @RecipeName varchar(100),
    @Calories int,
    @CreatedDate datetime output,
    @PublishedDate datetime output,
    @ArchivedDate datetime output,
    @Message varchar(500) = '' output
)
as
begin
    set nocount on;

    declare @Return int = 0;

    select @RecipeID = isnull(@RecipeID, 0);

    if @RecipeID = 0
    begin
        insert Recipe (CuisineID, UserId, RecipeName, Calories)
        values (@CuisineID, @UserId, @RecipeName, @Calories);

        set @RecipeID = scope_identity();
    end
    else
    begin
        update Recipe
        set
            CuisineID = @CuisineID,
            UserId = @UserId,
            RecipeName = @RecipeName,
            Calories = @Calories
        where RecipeID = @RecipeID;
    end

    return @Return;
end
go