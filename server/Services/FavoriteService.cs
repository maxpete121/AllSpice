namespace RecipeApp.Services;


public class FavoriteService(FavoriteRepository repo){
    private readonly FavoriteRepository repo = repo;

    internal Favorite CreateFavorite(Favorite newData, string userId){
        newData.AccountId = userId;
        Favorite favorite = repo.CreateFavorite(newData);
        return favorite;
    }

}