set nocount on;

declare @recipeid int;

select top 1 @recipeid = r.recipeid
from recipe r
left join mealcourserecipe mcr on r.recipeid = mcr.recipeid
left join cookbookrecipe cr on r.recipeid = cr.recipeid
where mcr.mealcourseid is null
  and cr.cookbookrecipeid is null
order by r.recipeid;

select * from (
    select top 1 'recipe' as source, r.recipeid, r.recipename
    from recipe r
    where r.recipeid = @recipeid
) as rec
union all
select * from (
    select top 1 'step' as source, rs.recipestepid, rs.stepdescription
    from recipestep rs
    where rs.recipeid = @recipeid
    order by rs.steporder
) as step
union all
select * from (
    select top 1 'ingredient' as source, ri.recipeingredientid, cast(ri.amount as varchar(20)) + ' units' as description
    from recipeingredient ri
    where ri.recipeid = @recipeid
) as ingr;

begin try
    begin transaction;
        delete from recipestep where recipeid = @recipeid;
        delete from recipeingredient where recipeid = @recipeid;
        delete from recipe where recipeid = @recipeid;
    commit transaction;
end try
begin catch
    rollback transaction;
    throw;
end catch;

select * from (
    select top 1 'recipe' as source, r.recipeid, r.recipename
    from recipe r
    where r.recipeid = @recipeid
) as rec_after
union all
select * from (
    select top 1 'step' as source, rs.recipestepid, rs.stepdescription
    from recipestep rs
    where rs.recipeid = @recipeid
) as step_after
union all
select * from (
    select top 1 'ingredient' as source, ri.recipeingredientid, cast(ri.amount as varchar(20)) + ' units' as description
    from recipeingredient ri
    where ri.recipeid = @recipeid
) as ingr_after;