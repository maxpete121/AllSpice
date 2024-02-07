namespace RecipeApp.Repositories;

public class RecipeRepository(IDbConnection db){
    private readonly IDbConnection db = db;

    
    internal Recipe CreateRecipe(Recipe recipeData){
        string sql = @"
        INSERT INTO Recipe
        (title, instructions, img, creatorId)
        VALUES
        (@title, @instructions, @img, @creatorId);

        SELECT
        Recipe.*,
        accounts.*
        FROM Recipe
        JOIN accounts ON Recipe.creatorId = accounts.id
        WHERE Recipe.id = LAST_INSERT_ID();
        ";

        Recipe recipe = db.Query<Recipe, Account, Recipe>(sql, (recipe, account)=>{
            recipe.Creator = account;
            return recipe;
        }, recipeData).FirstOrDefault();
        return recipe;
    }

    internal List<Recipe> GetRecipes(){
        string sql = @"
        SELECT
        Recipe.*,
        accounts.*
        FROM Recipe
        JOIN accounts ON Recipe.creatorId = accounts.id";
        List<Recipe> recipes = db.Query<Recipe, Account, Recipe>(sql, (recipes, account)=>{
            recipes.Creator = account;
            return recipes;
        }).ToList();
        return recipes;
    }
}
