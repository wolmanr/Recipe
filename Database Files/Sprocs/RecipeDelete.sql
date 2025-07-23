create or alter procedure recipedelete
(
    @recipeid int,
    @message varchar(500) = '' output
)
as
begin
    set nocount on;

    declare @return int = 0;
    set @message = '';

    if exists (
        select 1 from recipe r
        where r.recipeid = @recipeid
        and (
            (r.archiveddate is not null and datediff(day, r.archiveddate, getdate()) < 30)
            or r.recipestatus = 'published'
        )
    )
    begin
        set @return = 1;
        set @message = 'Cannot delete recipe that was archived less than 30 days ago or is published.';
        goto finished;
    end

    begin try
        begin tran;
            delete from recipestep where recipeid = @recipeid;
            delete from recipeingredient where recipeid = @recipeid;
            delete from recipe where recipeid = @recipeid;
        commit tran;
    end try
    begin catch
        rollback tran;
        throw;
    end catch

    finished:
    return @return;
end
go