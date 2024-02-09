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
        accounts.*
      FROM collaborators
      JOIN accounts ON favorites.accountId = accounts.id
      WHERE favorites.id = LAST_INSERT_ID()";
      Favorite favorite = db.Query<Favorite, Account, Favorite>(sql, (favorite, account)=>{
        favorite.RecipeId = newData.Id;
        return favorite;
      }, newData).FirstOrDefault();
      return favorite;
    }
}