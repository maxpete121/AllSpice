namespace RecipeApp.Repositories;

public class RecipeRepository(IDbConnection db){
    private readonly IDbConnection db = db;

    
    internal Recipes CreateRecipe(Recipes recipeData){
        string sql = @"
        INSERT INTO recipes
        (title, instructions, img, category, creatorId)
        VALUES
        (@title, @instructions, @img, @category, @creatorId);

        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = LAST_INSERT_ID();
        ";

        Recipes recipe = db.Query<Recipes, Account, Recipes>(sql, (recipe, account)=>{
            recipe.Creator = account;
            return recipe;
        }, recipeData).FirstOrDefault();
        return recipe;
    }

    internal List<Recipes> GetRecipes(){
        string sql = @"
        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id";
        List<Recipes> recipes = db.Query<Recipes, Account, Recipes>(sql, (recipes, account)=>{
            recipes.Creator = account;
            return recipes;
        }).ToList();
        return recipes;
    }
}
