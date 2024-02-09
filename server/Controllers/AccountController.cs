namespace RecipeApp.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly FavoriteService _favoriteService;
  private readonly RecipeService _recipeService;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, FavoriteService favoriteService, RecipeService recipeService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _favoriteService = favoriteService;
    _recipeService = recipeService;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("favorites")]
  [Authorize]
  public async Task<ActionResult<List<FavoriteRecipe>>> GetAccountFavorites(){
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string userId = userInfo.Id;
      List<FavoriteRecipe> favorite = _favoriteService.GetAccountFavorites(userId);
      return Ok(favorite);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("recipes")]
  [Authorize]

  public async Task<ActionResult<List<Recipes>>> GetAccountRecipes(string userId){
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Recipes> recipes = _recipeService.GetAccountRecipes(userId);
      return Ok(recipes);
    }
    catch (System.Exception)
    {
      
      throw;
    }
  }
}
