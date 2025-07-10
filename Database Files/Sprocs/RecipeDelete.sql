create or alter procedure RecipeDelete(@recipeid int)
as 
begin
    begin try
    begin tran
        delete recipe where recipeId = @recipeid
        commit
    end try

    begin catch
    rollback;
    throw
    end catch
end