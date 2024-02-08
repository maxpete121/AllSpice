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
        title = @Title,
        instructions = @Instructions,
        img = @Img,
        category = @Category
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
}
//   id INT AUTO_INCREMENT PRIMARY KEY,
//   title VARCHAR(40) NOT NULL,
//   instructions VARCHAR(500) NOT NULL,
//   img VARCHAR(500) NOT NULL,
//   category ENUM ("Cheese", "Italian", "Soup", "Mexican", "Specialty Coffee") DEFAULT "Soup",
//   creatorId VARCHAR(255) NOT NULL,