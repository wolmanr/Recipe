declare @recipeid int

select top 1 @recipeid = r.RecipeID
from recipe R
left join RecipeStep rs
on r.RecipeID = rs.RecipeId
left join CookbookRecipe cr
on r.RecipeID = cr.RecipeId
where rs.RecipeStepId is null
and cr.CookbookRecipeId is null

select * from recipe r where r.RecipeID = @recipeid

exec RecipeDelete @recipeid = @recipeid


select * from recipe r where r.RecipeID = @recipeid