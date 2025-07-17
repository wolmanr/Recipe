create or alter procedure Recipedelete(@recipeid int)
as 
begin
    begin try
    begin tran
        delete from RecipeStep where RecipeId = @recipeid;
        delete from RecipeIngredient where RecipeId = @recipeid;
        delete from Recipe WHERE RecipeId = @recipeid;
        commit
    end try

    begin catch
    rollback;
    throw
    end catch
end