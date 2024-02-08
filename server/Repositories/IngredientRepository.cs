namespace RecipeApp.Repositories;


public class IngredientRepository(IDbConnection db){
    private readonly IDbConnection db = db;

    internal Ingredient CreateIngredient(Ingredient ingredientData){
        string sql = @"
        INSERT INTO ingredients
        (name, quantity, recipeId)
        VALUES
        (@Name, @Quantity, @RecipeId);

        SELECT
        ingredients.*,
        recipes.*
        FROM ingredients
        JOIN recipes ON ingredients.recipeId = recipes.id
        WHERE ingredients.id = LAST_INSERT_ID()";
        Ingredient ingredient = db.Query<Ingredient, Recipes, Ingredient>(sql, (ingredient, recipe)=>{
            ingredient.RecipeId = recipe.Id;
            return ingredient;
        }, ingredientData).FirstOrDefault();
        return ingredient;
    }
}