using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace RecipeApp.Controllers;

[ApiController]
[Route("api/recipes")]

public class RecipeController : ControllerBase{
    private readonly RecipeService recipeService;
    private readonly Auth0Provider auth;
    public RecipeController(Auth0Provider auth, RecipeService recipeService){
        this.auth = auth;
        this.recipeService = recipeService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
            Recipe recipe = recipeService.CreateRecipe(recipeData);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }
}