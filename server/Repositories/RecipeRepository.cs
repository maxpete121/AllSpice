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

    internal Recipes GetRecipeById(int recipeId){
        string sql = @"
        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = @recipeId";
        Recipes recipes = db.Query<Recipes, Account, Recipes>(sql, (recipes, account)=>{
            recipes.Creator = account;
            return recipes;
        }, new{recipeId}).FirstOrDefault();
        return recipes;
    }

    internal Recipes EditRecipe(Recipes updateData){
        string sql = @"
        UPDATE recipes SET
        title = @title,
        instructions = @instructions,
        img = @img,
        category = @category
        WHERE id = @id;

        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = @id";
        Recipes recipes = db.Query<Recipes, Account, Recipes>(sql, (recipes, account)=>{
            recipes.Creator = account;
            return recipes;
        }, updateData).FirstOrDefault();
        return recipes;
    }

    internal void RemoveRecipe(int recipeId){
        string sql = @"
        DELETE FROM recipes
        WHERE id = @recipeId";
        db.Execute(sql, new{recipeId});
    }

    internal List<Recipes> GetAccountRecipes(string userId){
        string sql = @"
        SELECT
        *
        FROM recipes
        WHERE creatorId = @userId";
        List<Recipes> recipe = db.Query<Recipes>(sql, new{userId}).ToList();
        return recipe;
    }

    internal List<Recipes> GetRecipeByQuery(string query){
        string sql = @"
        SELECT
        *
        FROM recipes
        WHERE category = @query
        ";
        List<Recipes> recipe = db.Query<Recipes>(sql, new{query}).ToList();
        return recipe;
    }
}
