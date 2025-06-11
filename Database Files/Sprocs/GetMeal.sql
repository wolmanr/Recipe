create or alter procedure GetMeal(@All bit = 0, @MealId int = 0, @MealName varchar(100) = '')
as
BEGIN
    select @MealName = nullif(@MealName,'')
    select m.MealId, m.MealName, m.PictureMeal, m.MealStatus, m.CreatedDate
    from meal m
    where m.MealId = @mealId
    or @all = 1
    or m.MealName like '%' + @mealName + '%'
END
go

exec GetMeal

exec GetMeal @all = 1

exec GetMeal @MealId = 4

exec GetMeal @MealName = ''

exec GetMeal @MealName = 'y'

exec GetMeal @All = 0, @mealId = 2, @mealName = 'r'

declare @MealId int

select top 1 @mealId = m.MealId from meal m

exec GetMeal @MealId =@mealId