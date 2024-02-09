namespace RecipeApp.Controllers;


public class FavoritesController : ControllerBase{
    private readonly FavoriteService favoriteService;
    private readonly Auth0Provider auth;

        public FavoritesController(Auth0Provider auth, FavoriteService favoriteService){
        this.auth = auth;
        this.favoriteService = favoriteService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite newData){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            Favorite favorite = favoriteService.CreateFavorite(newData, userInfo.Id);
            return Ok(favorite);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }
}