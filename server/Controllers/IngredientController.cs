namespace RecipeApp.Controllers;

[ApiController]
[Route("api/ingredients")]

public class IngredientController : ControllerBase{
    private readonly IngredientService ingredientService;
    private readonly Auth0Provider auth;

    public IngredientController(Auth0Provider auth, IngredientService ingredientService){
        this.auth = auth;
        this.ingredientService = ingredientService;
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Ingredient> CreateIngredient([FromBody] Ingredient ingredientData){
        try
        {
            Ingredient ingredient = ingredientService.CreateIngredient(ingredientData);
            return Ok(ingredient);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }
    [HttpDelete("{ingredientId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteIngredient(int ingredientId){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            string message = ingredientService.DeleteIngredient(ingredientId, userInfo.Id);
            return Ok(message);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }
    

}