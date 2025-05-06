📚 Recipe Management Database Schema
This schema supports a complete recipe platform where users can create, organize, and share meals, cookbooks, and recipes with detailed steps and ingredients.

👤 User
Stores user profiles with unique usernames.

🍴 Cuisine
Defines various cuisine types (e.g., Italian, Thai).

📖 Recipe
Represents user-created recipes, including name, cuisine, calories, status (Draft/Published/Archived), and timestamps.

🪜 RecipeStep
Holds ordered step-by-step instructions for recipes.

🧂 Ingredient
Master list of ingredients with optional images.

⚖️ Measurement
List of standard units of measurement (e.g., grams, cups).

🧪 RecipeIngredient
Joins recipes with ingredients, including quantity, unit, and display order.

🥗 Meal
User-defined meals with names, images, creation date, and active status.

🧾 Course
Defines meal sections like appetizers, mains, and desserts, with ordering.

🍛 MealCourse
Connects meals to their courses, ensuring unique combinations.

🍲 CourseRecipe
Links recipes to specific courses within a meal.

📘 Cookbook
User-created collections of recipes with names, prices, images, and status.

📗 CookbookRecipe
Maps recipes into a cookbook with a defined sequence.
