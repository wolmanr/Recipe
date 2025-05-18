use master
go
drop database if exists RecipeDB
go
create database RecipeDB
go
use RecipeDB
drop table if exists dbo.Recipe;
GO

create table dbo.Recipe(
    RecipeID int not null identity primary key,
    CuisineID int not null constraint f_Cuisine_Recipe FOREIGN key REFERENCES Cuisine(CuisineID),
    UserId int not null constraint f_User_Recipe FOREIGN KEY REFERENCES Users(UserId),
    RecipeName varchar(100) not null,
    PictureRecipe as CONCAT('Recipe_', REPLACE(RecipeName, ' ', ''), '.jpg'),
    Calories int not null ,
    CreatedDate datetime not null,
    PublishedDate datetime null,
    ArchivedDate datetime null,
    RecipeStatus as case 
                    when ArchivedDate is not null then 'Archived'
                    when PublishedDate is not null then 'Published'
                    else 'Draft' end persisted
)
go

use recipedb
go


delete from Recipe;

go


insert  Cuisine(CuisineName)
select 'american'
union select 'french'
union select 'english'
union select 'italian';
go

insert  dbo.Recipe(CuisineId, UserId, RecipeName, Calories, CreatedDate, PublishedDate, ArchivedDate)
select c.CuisineId, u.UserId, r.RecipeName, r.Calories, r.CreatedDate, r.PublishedDate, r.ArchivedDate
from
    (values 
        ('chocolate chip cookies', 100, '2005-07-01', '2005-11-25', null, 'american', 'janesmith'),
        ('apple yogurt smoothie', 50, '2019-04-18', '2019-07-21', '2023-09-21', 'french', 'janesmith'),
        ('cheese bread', 130, '2021-07-14', '2021-08-12', null, 'english', 'frankslin'),
        ('butter muffins', 60, '2022-11-27', '2023-01-14', '2024-01-01', 'american', 'larygrim'),
        ('chocolate cake', 100, '2005-07-01', null, null, 'american', 'johndoe')
    ) as r (RecipeName, Calories, CreatedDate, PublishedDate, ArchivedDate, CuisineName, UserName)
join dbo.Cuisine c on c.CuisineName = r.CuisineName
join dbo.Users u on u.UserName = r.UserName;
go