create or alter procedure recipedelete
(
    @recipeid int,
    @message varchar(500) = '' output
)
as
begin
    set nocount on;
 declare @return int = 0
    if exists (
        select * from recipe r
        where r.recipeid = @recipeid
        and (
            (r.archiveddate is not null and datediff(day, r.archiveddate, getdate()) < 30)
            or r.recipestatus <> 'draft'
        )
    )
    begin
        select @return = 1, @message = 'cannot delete recipe that was archived less than 30 days ago or is not in draft status.'
        goto finished
    end

    begin try
        begin tran
        delete from recipestep where recipeid = @recipeid;
        delete from recipeingredient where recipeid = @recipeid;
        delete from recipe where recipeid = @recipeid;
        commit tran
    end try
    begin catch
        rollback tran
        throw
    end catch

    finished:
    return @return
end
go