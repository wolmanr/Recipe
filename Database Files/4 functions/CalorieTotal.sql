create or alter function CalorieTotal(@MealId int)
returns varchar (30)
as
begin
    declare @value varchar(30) = ''
        select @value = concat(m.MealName, ' ', sum(isnull(r.Calories, 0))) 
        from meal m
         join MealCourse mc 
            on m.MealId = mc.MealId
         join MealCourseRecipe mcr 
            on mc.MealCourseId = mcr.MealCourseID
         join Recipe r 
            on r.RecipeId = mcr.RecipeId
        where m.mealId = @MealId
        group by m.MealName
      
    return @value
end
go

select TotalCalories = dbo.CalorieTotal(r.RecipeId)
from recipe r