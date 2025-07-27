create or alter function dbo.recipeinfo(@recipeid int)
returns varchar(250)
as
begin
    declare @value varchar(250) = ''
    
    select @value = concat(
         r.recipename,
        ' (', c.cuisinename, ')',
        ' has ', 
            (select count(*) from recipeingredient where recipeid = r.recipeid), 
            ' ingredients',
        ' and ', 
            (select count(*) from recipestep where recipeid = r.recipeid), 
            ' recipe steps'
    )
    from recipe r
    join cuisine c on r.cuisineid = c.cuisineid
    where r.recipeid = @recipeid

    return @value
end
go

select RecipeInfo = dbo.RecipeInfo(r.recipeId), *
from recipe r