create or alter procedure CuisineGet(@CuisineId int = 0, @all bit = 0, @CuisineName varchar(50) = '')
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

exec CuisineGet

exec CuisineGet @all = 0

exec CuisineGet @cuisineId = 3, @all = 1

exec CuisineGet @cuisineName = ''

exec CuisineGet @cuisineName = 'r'

declare @cuisineId int

select top 1 @cuisineId = c.CuisineId from Cuisine c

exec CuisineGet @cuisineId = @cuisineId