use master
go
drop database if exists RecipeDB
go
create database RecipeDB
go
use RecipeDB
drop table if exists dbo.Recipe;
GO

go
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