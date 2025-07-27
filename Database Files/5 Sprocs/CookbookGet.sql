create or alter procedure CookbookGet(@CookbookId int = 0, @all bit = 0, @CookbookName varchar(225) = '')
as
BEGIN
    select @CookbookName = nullif(@CookbookName,'')
    select c.CookbookId, c.CookbookName, c.PictureName, c.Price, c.CookbookStatus, c.CreatedDate
    from Cookbook c
    where c.CookbookId = @CookbookId
    or @all = 1
    or c.CookbookName like '%' + @CookbookName + '%'
END
go

exec CookbookGet

exec CookbookGet @all = 0

exec CookbookGet @cookbookId = 3, @all = 1

exec CookbookGet @cookbookName = ''

exec CookbookGet @cookbookName = 'r'

declare @cookbookId int

select top 1 @cookbookId = c.CookbookId from Cookbook c

exec CookbookGet @cookbookId = @CookbookId