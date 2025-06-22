Use RecipeDB
go
create or alter procedure RecipeUpdate
    @recipeid int = 0,
    @userid int = 0,
    @cuisineid int = 0,
    @recipename varchar(100) = '',
    @calories int = 0,
    @createddate date = null,
    @publisheddate date = null,
    @archiveddate date = null
as
begin
    update recipe
    set 
        userid = @userid,
        cuisineid = @cuisineid,
        recipename = @recipename,
        calories = @calories,
        createddate = @createddate,
        publisheddate = @publisheddate,
        archiveddate = @archiveddate
    where recipeid = @recipeid;
end
go
exec recipeupdate
    @recipeid = 1,
    @userid = 2,
    @cuisineid = 3,
    @recipename = 'My updated recipe',
    @calories = 350,
    @createddate = '2024-01-01',
    @publisheddate = NULL,
    @archiveddate = NULL;