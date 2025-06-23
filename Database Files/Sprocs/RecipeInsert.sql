create or alter procedure dbo.recipeinsert
    @userid int,
    @cuisineid int,
    @recipename varchar(100),
    @calories int,
    @createddate date = null,
    @publisheddate date = null,
    @archiveddate date = null,
    @recipeid int output
as
begin
    insert into recipe (userid, cuisineid, recipename, calories, createddate, publisheddate, archiveddate)
    values (@userid, @cuisineid, @recipename, @calories, @createddate, @publisheddate, @archiveddate);

    set @recipeid = scope_identity();
end


GRANT EXECUTE ON dbo.recipeupdate TO dev_recipeuser;