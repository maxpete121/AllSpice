namespace RecipeApp.Repositories;


public class FavoriteRepository(IDbConnection db){
    private readonly IDbConnection db = db;

    internal Favorite CreateFavorite(Favorite newData){
        string sql = @"
         INSERT INTO favorites
      (accountId, recipeId)
      VALUES
      (@accountId, @recipeId);

      SELECT
     favorites.*,
     recipes.*
      FROM favorites
      JOIN recipes ON favorites.recipeId = @recipeId
      WHERE favorites.id = LAST_INSERT_ID()";
      Favorite favorite = db.Query<Favorite, Recipes, Favorite>(sql, (favorite, recipe)=>{
        favorite.AccountId = recipe.CreatorId;
        return favorite;
      }, newData).FirstOrDefault();
      return favorite;
    }

    internal List<FavoriteRecipe> GetAccountFavorites(string userId){
        string sql = @"
      SELECT
     recipes.*,
     favorites.*,
     accounts.*
      FROM favorites
      JOIN recipes ON favorites.recipeId = recipes.id
      JOIN accounts ON recipes.creatorId = accounts.id
      WHERE favorites.accountId = @userId";
    List<FavoriteRecipe> favorite = db.Query<FavoriteRecipe, Recipes, Account, FavoriteRecipe>(sql, (favorite, recipe, account)=>{
        favorite.FavoriteId = favorite.Id;
        favorite.Creator = account;
        return favorite;
    }, new{userId}).ToList();
    return favorite;
    }
}