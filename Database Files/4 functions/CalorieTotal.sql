create or alter function CalorieTotal(@MealId int)
returns varchar (30)
as
begin
    declare @value varchar(30) = ''
        select @value = concat(m.MealName, ' ', sum(isnull(r.Calories, 0))) 
        from meal m
        left join MealCourse mc 
            on m.MealId = mc.MealId
        left join MealCourseRecipe mcr 
            on mc.MealCourseId = mcr.MealCourseID
        left join Recipe r 
            on r.RecipeId = mcr.RecipeId
        where m.mealId = @MealId
        group by m.MealName
      
    return @value
end
go

select TotalCalories = dbo.CalorieTotal(r.RecipeId)
from recipe r