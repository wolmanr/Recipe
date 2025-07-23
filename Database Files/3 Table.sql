--AS Fantastic job! 100%
use RecipeDB  
go
drop table if exists CookbookRecipe
drop table if exists dbo.MealCourseRecipe;
drop table if exists dbo.MealCourse;
drop table if exists dbo.RecipeIngredient;
drop table if exists dbo.RecipeStep;
drop table if exists dbo.Meal;
drop table if exists dbo.Cookbook;
drop table if exists dbo.Course;
drop table if exists dbo.Recipe;
drop table if exists dbo.Ingredient;
drop table if exists dbo.Measurement;
drop table if exists dbo.Cuisine;
drop table if exists dbo.Users;
GO

create table dbo.Users(
    UserId int identity PRIMARY key,
    FirstName varchar(100) not null
        constraint ck_Users_first_name_cannot_be_blank check(FirstName <> ''),
     LastName varchar(100) not null
        constraint ck_Users_last_name_cannot_be_blank check(LastName <> ''),
    UserName varchar(150) not null 
        constraint ck_Users_username_cannot_be_blank check(UserName <> '')
        constraint U_Users_username unique
)
go
create table dbo.Cuisine(
    CuisineId int identity primary key,
    CuisineName varchar(50) not null
        constraint ck_Cuisine_name_cannot_be_blank check(CuisineName <> '')
        constraint uk_Cuisine_name unique
)
go
create table dbo.Recipe(
    RecipeID int not null identity primary key,
    CuisineID int not null constraint f_Cuisine_Recipe FOREIGN key REFERENCES Cuisine(CuisineID),
    UserId int  null constraint f_User_Recipe FOREIGN KEY REFERENCES Users(UserId),
    RecipeName varchar(100) not null
        constraint ck_Recipe_name_cannot_be_blank check(RecipeName <> '')
        constraint U_Recipe_name unique,
    PictureRecipe as CONCAT('Recipe_', REPLACE(RecipeName, ' ', ''), '.jpg'),
    Calories int not null 
        constraint Recipe_calories_cannot_be_negative check(Calories >= 0),
    CreatedDate datetime not null
    constraint ck_created_date_cannot_be_future_date_and_must_be_before_1_1_1990 check (CreatedDate between '1/1/1990' and getdate()),
    PublishedDate datetime null
        constraint ck_published_date_cannot_be_future_date check(PublishedDate < getdate()),
    ArchivedDate datetime null
        constraint ck_archived_date_cannot_be_future_date check(ArchivedDate < getdate()),
    RecipeStatus as case 
                    when ArchivedDate is not null then 'Archived'
                    when PublishedDate is not null then 'Published'
                    else 'Draft' end persisted,
        constraint ck_Created_date_must_be_before_published check (CreatedDate < PublishedDate),
        constraint ck_PublishedDate_and_createddDate_must_be_before_archived_date check (PublishedDate < ArchivedDate and CreatedDate < ArchivedDate)
)
go
create table dbo.RecipeStep(
    RecipeStepId INT not null identity primary key,
    RecipeId INT not null constraint f_Recipe_step FOREIGN KEY REFERENCES Recipe(RecipeId),
    StepOrder int not null
        constraint ck_RecipeStep_StepOrder_must_be_greater_than_zero check (StepOrder > 0),
    StepDescription varchar (300) not null 
        constraint ck_RecipeStep_step_description_cannot_be_blank check (StepDescription <> ''),
        constraint U_RecipeStep_RecipeId_StepOrder unique (RecipeId, StepOrder)
)
GO
create table dbo.Ingredient(
    IngredientId int not null identity primary key,
    IngredientName varchar (100) not null
        constraint ck_Ingredient_name_cannot_be_blank check (ingredientName <> ''),
    PictureIngredient as CONCAT('Ingredient', REPLACE(IngredientName, ' ', ''), '.jpg'),
)
GO
create table dbo.Measurement(
    MeasurementId int not null identity primary key,
    Measurement varchar (50) null 
        constraint ck_Measurement_cannot_be_blank check (Measurement <> '') 
        constraint u_Measurement unique 
)
go
create table dbo.RecipeIngredient(
    RecipeIngredientId int not null identity primary key,
    RecipeId int not null constraint f_Recipe_recipeIngredient FOREIGN key REFERENCES Recipe(recipeId),
    IngredientId int not null constraint f_Ingredient_Recipeingredient FOREIGN KEY REFERENCES Ingredient(IngredientId),
    MeasurementId int not null constraint f_Measurement_recipeIngredient FOREIGN key REFERENCES Measurement(MeasurementId),
    Amount decimal(10,2) not null
       constraint ck_RecipeIngredient_amount_cannot_be_negative check(Amount >=0),
    RecipeIngredientSequence int not null 
        constraint ck_RecipeIngredient_order_cannot_be_negative check(RecipeIngredientSequence > 0),
        constraint U_RecipeId_IngredientId unique (RecipeId, IngredientId),
        constraint U_IngredientId_recipeId_RecipeIngredientOrder unique (IngredientId, RecipeId, RecipeIngredientSequence)
)
go
create table dbo.meal(
    MealId int not null identity primary key,
    UserId int not null constraint f_User_meal FOREIGN key REFERENCES Users(UserId),
    MealName varchar(100) not NULL      
        constraint ck_Meal_name_cannot_be_blank check (MealName <> '')
        constraint u_Meal_name unique,
    PictureMeal AS CONCAT('Meal_', REPLACE(MealName, ' ', ''), '.jpg'),
    MealStatus bit not null,
    CreatedDate datetime not null 
        constraint ck_created_date__for_a_meal_must_be_after_1_1_1990_and_not_in_the_future check(CreatedDate between '1/1/1990' and getdate())   
)
GO
create table dbo.Course(
    CourseId int not null identity primary key,
    CourseName varchar (100) not null 
        constraint ck_Course_name_cannot_be_blank check(CourseName <> ''),
    CourseOrder int not null 
        constraint ck_Course_order_cannot_be_negative check(CourseOrder > 0)
)
GO
create table dbo.MealCourse(
    MealCourseID int not null identity primary key,
    MealID int not null constraint f_MealCourse_meal foreign key REFERENCES Meal(MealId),
    CourseID int not null constraint f_MealCourse_course foreign key REFERENCES Course(CourseID),
    constraint u_Meal_course unique(MealId, CourseId)
)
go
Create table dbo.MealCourseRecipe(
    CourseRecipeId int not null identity primary key,
    RecipeId int not null constraint f_CourseRecipe_recipe foreign key REFERENCES recipe(recipeId),
    MealCourseID int not null constraint f_CourseRecipe_mealCourse foreign key REFERENCES MealCourse(MealCourseID),
    IsMainDish bit not null,
        constraint u_Recipe_mealCourse unique (recipeID, MealCourseId)
)
go
create table dbo.Cookbook(
    CookbookId int not null identity primary key,
    UserId int not null constraint f_Cookbook_user foreign key REFERENCES Users(userId),
    CookbookName varchar(255) not null 
        constraint ck_Cookbook_name_cannot_be_blank check(CookbookName <> '') 
        constraint u_Cookbook_name unique,
    PictureName AS CONCAT('cookbook_', REPLACE(CookbookName, ' ', ''), '_.jpg'),
    Price decimal(10,2) not null 
        constraint ck_cookbook_price_cannot_be_negative check(Price >= 0),
    CookbookStatus bit not null,
    CreatedDate DateTime not null
         constraint ck_created_date_for_cookbook_must_be_after_1_1_1990_and_not_in_the_future check(CreatedDate between '1/1/1990' and getdate())   
)
go
create table dbo.CookbookRecipe(
    CookbookRecipeId int not null identity primary key,
    CookbookId int not null constraint f_CookbookRecipe_cookbook foreign key REFERENCES Cookbook(CookbookId),
    RecipeId int not null constraint f_CookbookRecipe_recipe foreign key REFERENCES Recipe(recipeId),
    CookbookRecipeSequence int not null 
        constraint ck_Cookbookrecipe_sequence_must_be_greater_than_zero check(CookbookRecipeSequence > 0),
        constraint u_Cookbook_recipe unique (cookbookId, recipeId)
)

ALTER TABLE Recipe ALTER COLUMN UserId INT NULL;
ALTER TABLE Recipe ALTER COLUMN CuisineId INT NULL;

