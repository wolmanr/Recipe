create or alter procedure GetCookbook(@CookbookId int = 0, @all bit = 0, @CookbookName varchar(225) = '')
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

exec GetCookbook

exec GetCookbook @all = 0

exec GetCookbook @cookbookId = 3, @all = 1

exec GetCookbook @cookbookName = ''

exec GetCookbook @cookbookName = 'r'

declare @cookbookId int

select top 1 @cookbookId = c.CookbookId from Cookbook c

exec GetCookbook @cookbookId = @CookbookId