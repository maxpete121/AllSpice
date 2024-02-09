namespace RecipeApp.Controllers;

[ApiController]
[Route("api/favorites")]

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
            newData.AccountId = userInfo.Id;
            Favorite favorite = favoriteService.CreateFavorite(newData);
            return Ok(favorite);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }
}