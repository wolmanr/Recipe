/*
--MG you are good to go, just be consistent with naming so either Order or Sequence

User Table
    UserId PK
    FirstName Varchar not null not blank
    LastName varchar not null not blank
    UserName not null not blank unique

Cuisine Table
    CuisineId PK
    CuisineName varchar not null unique not blank

Recipe Table
    RecipeId PK
    CuisineId FK to Cuisine
    UserId FK to User
    RecipeName varchar unique not null not blank
    PictureName as when ('Recipe' + '_' +  recipeName + '_' + '.jpg')
    Calories int not null not negative
    CreatedDate not null datetime
    PublishedDate null datetime
    ArchivedDate null datetime
    RecipeStatus case when ArchivedAt is not null then 'Archived'
                    when PublishedAt is not null then 'Published'
                    else 'Draft' end persisted

RecipeStep Table (
    RecipeStepId INT PK,
    RecipeId INT FK on recipe,
    StepOrder INT NOT NULL,  
    StepDescription varchar not null not blank

Ingredient Table
    IngredientId PK
    PictureIngredient varchar not null not blank
    IngredientName varchar not null not blank

Measurement Table(
    MeasurementId PK
    --RW should this column be unique?
	--MG Yes, it is a master list
    UnitOfMeasure varchar not null not blank
    
)

RecipeIngredient Table
    RecipeIngredientId PK
    RecipeId FK to recipe
    IngredientId FK to ingredient 
    UnitOfMeasureId FK to UnitOfMeasure
    Amount decimal(10,2) not null not negative
	RecipeIngredientSequence int not null not negative
        recipe to ingeredient unique
        (IngredientID RecipeId Sequence) unique

Meal Table
    MealId PK
    UserId FK to user
    MealName varchar not null not blank
    PictureName AS ('meal_' + '_' +  MEAL_NAME + '_' +  '.jpg'),
    MealStatus bit not null
    CreatedAt datetime not null


Course Table
    CourseId PK
    CourseName varchar not null not blank
    CourseOrder int not null not negative


MealCourseTable(
    MealCourseID PK
    MealID FK to meal
    CourseID FK to course
    meal and course unique
)

CourseRecipe Table
    CourseRecipeId PK
    RecipeId FK to recipe
    MealCourseId fk to mealcourse
        unique (recipeID, MealCourseId)

Cookbook Table
    CookbookId PK
    UserId FK to User
    CookbookName varchar not null not blank unique
    PictureName AS ('cookbook_' + '_' + COOKBOOK_NAME + '_.jpg')
    Price decimal(10,2) not null not negative
    CookbookStatus bit not null
    CreatedDate DateTime not null

CookbookRecipeTable
    CookbookRecipeId PK
    CookbookId FK to cookbook
    RecipeId FK to recipe
    CookbookRecipeSequence int not null not negative
        unique cookbook to recipe


*/