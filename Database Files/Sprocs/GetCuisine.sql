create or alter procedure GetCusine(@CuisineId int = 0, @all bit = 0, @CuisineName varchar(50) = '')
as
BEGIN
    select @CuisineName = nullif(@CuisineName,'')
    select  c.CuisineId, c.CuisineName
    from Cuisine c
    where c.CuisineId = @CuisineId
    or @all = 1
    or c.CuisineName like '%' + @CuisineName + '%'
END
go

exec GetCusine

exec GetCusine @all = 0

exec GetCusine @cuisineId = 3, @all = 1

exec GetCusine @cuisineName = ''

exec GetCusine @cuisineName = 'r'

declare @cuisineId int

select top 1 @cuisineId = c.CuisineId from Cuisine c

exec GetCusine @cuisineId = @cuisineId