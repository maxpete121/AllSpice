namespace RecipeApp.Services;


public class FavoriteService(FavoriteRepository repo){
    private readonly FavoriteRepository repo = repo;

    internal Favorite CreateFavorite(Favorite newData){
        Favorite favorite = repo.CreateFavorite(newData);
        return favorite;
    }

    internal List<FavoriteRecipe> GetAccountFavorites(string userId){
        List<FavoriteRecipe> favorite = repo.GetAccountFavorites(userId);
        return favorite;
    }
}