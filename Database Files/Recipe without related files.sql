insert  dbo.Recipe(CuisineId, UserId, RecipeName, Calories, CreatedDate, PublishedDate, ArchivedDate)
select c.CuisineId, u.UserId, r.RecipeName, r.Calories, r.CreatedDate, r.PublishedDate, r.ArchivedDate
from
    (values 
        ('chicken ', 100, '2015-07-01', '2018-11-25', null, 'american', 'janesmith')  
    ) as r (RecipeName, Calories, CreatedDate, PublishedDate, ArchivedDate, CuisineName, UserName)
join dbo.Cuisine c on c.CuisineName = r.CuisineName
join dbo.Users u on u.UserName = r.UserName;

select * from recipe

