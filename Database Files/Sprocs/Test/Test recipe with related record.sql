declare @recipeid int

select top 1 @recipeid = r.RecipeID
from recipe R
join RecipeStep rs
on r.RecipeID = rs.RecipeId


select * from recipe r where r.RecipeID = @recipeid

exec RecipeDelete @recipeid = @recipeid