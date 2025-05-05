/*

Recipe Management System
The system is designed to manage recipes, meals, and cookbooks while tracking their details and lifecycle. Below is a breakdown of the key components and their relationships.

1. Recipe
A recipe represents a cooking procedure and is associated with a specific cuisine type (e.g., Mediterranean, Chinese). Each recipe has the following attributes:

    a) Cuisine Type: Defines the style or region of the recipe (e.g., Mediterranean, Chinese, etc.). The system maintains a master list of cuisines. 
    When a new recipe is added, its cuisine type must be included in this list if it doesn’t already exist.

    b) Ingredients: A recipe consists of a list of ingredients. Each ingredient has:

        1. Amount: The quantity required for the recipe.
        2. Measurement Type: The unit of measurement (e.g., teaspoons, cups, grams).
        3. Order of Ingredients: The ingredients in the recipe must be listed in a specific order. This order is important and should be followed strictly, as determined by the recipe authors.

    c) Status: Recipes have a status that tracks their lifecycle:

        Draft: Initially, a recipe is created and is in a draft state.
        Published: Once finalized, the recipe is published.
        Archived: After some time, if the recipe is no longer needed, it is moved to the archive (but not deleted). The system should track the following dates:
        Date and time when the recipe became a draft.
        Date and time when the recipe was published.
        Date and time when the recipe was archived.

    d) Pictures: Each recipe can have an associated picture. The picture should follow the naming convention:

        Naming convention: The file name will start with the type (e.g., "recipe") followed by the name of the recipe.
        Example: recipe_spaghetti_bolognese.jpg
        The image will be stored in a location associated with the recipe.

    e)Created By: Each recipe is created or updated by a staff member.
     The system should record the staff member’s first name, last name, and username to track who was responsible for creating or updating the recipe.

2. Meal
A meal is a combination of different courses, each representing a part of the meal (e.g., appetizer, main course, dessert). Meals have the following attributes:

    a) Meal Name: The name of the meal (e.g., "Italian Feast").

    b) Courses: A meal can consist of one or more courses. Each course:

         Has a type (e.g., appetizer, main course, dessert).
         Can include multiple recipes. Each recipe in the course is presented in a specific sequence.
         Has a sequence within the meal, which determines the order in which the courses appear (e.g., appetizer first, main course second, dessert third).
         Course Type Uniqueness: A meal should never contain more than one instance of the same type of course. For example, a meal should not have two main courses.

    c) Active/Inactive Status: Each meal can either be:

            Active: The meal is available on the site.
            Inactive: The meal is not currently available on the site.
            This status does not require specific date and time tracking but should be easily updated.

    d) Pictures: Each meal can have an associated picture. The picture should follow the naming convention:

        Naming convention: The file name will start with the type (e.g., "meal") followed by the name of the meal.
        Example: meal_italian_feast.jpg
        The image will be stored in a location associated with the meal.

    e) Created By: Each meal is created or updated by a staff member. 
    The system should record the staff member’s first name, last name, and username to track who was responsible for creating or updating the meal.

3. Cookbook
A cookbook is a collection of recipes, organized for sale or sharing. Each cookbook has:

    a) Cookbook Name: The name of the cookbook (e.g., "A Taste of Italy").

    b) Price: The cost of the cookbook.

    c)Recipes: The cookbook contains a list of recipes, and these recipes are presented in a specific order or sequence.

    d) Active/Inactive Status: Each cookbook can either be:

            Active: The cookbook is available on the site.
            Inactive: The cookbook is not currently available on the site.
            This status does not require specific date and time tracking but should be easily updated.

    e) Pictures: Each cookbook can have an associated picture. The picture should follow the naming convention:

        Naming convention: The file name will start with the type (e.g., "cookbook") followed by the name of the cookbook.
        Example: cookbook_a_taste_of_italy.jpg
        The image will be stored in a location associated with the cookbook.

    f) Created By: Each cookbook is created or updated by a staff member. 
    The system should record the staff member’s first name, last name, and username to track who was responsible for creating or updating the cookbook.

4. Ingredient
Each ingredient in the recipe has the following attributes:

    a) Name: The name of the ingredient (e.g., "Baby Carrot").

    b)Amount: The quantity required in the recipe.

    c)Measurement Type: The unit of measurement (e.g., teaspoons, cups, grams).

    d)Created By: Each ingredient is created or updated by a staff member. 
    The system should record the staff member’s first name, last name, and username to track who was responsible for creating or updating the ingredient.

    e)Pictures: Each ingredient can have an associated picture. The picture should follow the naming convention:

        Naming convention: The file name will start with the type (e.g., "ingredient") followed by the name of the ingredient.
        Example: ingredient_baby_carrot.jpg
        The image will be stored in a location associated with the ingredient.
    
Recipe Names: A recipe name must be unique across the system.
Meal: A meal must not contain duplicate course types.
Cookbook: A recipe should only appear once in a cookbook, and each recipe in the cookbook must be presented in a unique sequence.
Picture Naming: Each picture associated with a recipe, meal, ingredient, or cookbook must follow the specified naming convention.

5. Staff
Staff members are users responsible for creating or updating recipes, meals, cookbooks, and ingredients within the system. Each staff member has the following attributes:

    a)First Name: The first name of the staff member.
    b)Last Name: The last name of the staff member.
    c)Username: A unique username for login and tracking activities on the site.
    d)The Created By field for recipes, meals, cookbooks, and ingredients will be associated with the staff member’s username to track who was responsible for adding or modifying the content.


*/