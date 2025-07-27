create or alter procedure UserGet(@UserId int = 0, @All bit = 0, @username varchar(100) = '')
as
begin
    select @username = nullif(@username, '')
    select u.UserId, u.FirstName, u.LastName, u.UserName
    from Users u
    where @UserId = u.UserId
    or @All = 1
    or u.UserName like '%' + @username + '%'
end 
go

exec UserGet

exec UserGet @userId = 4, @all = 0

exec UserGet @All = 1

exec UserGet @userName = ''

exec UserGet @username = 'a'

declare @userId int

select top 1 @userId = u.UserId from Users u

exec UserGet @userId = @userId
