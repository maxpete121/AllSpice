using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace RecipeApp.Controllers;

[ApiController]
[Route("api/recipes")]

public class RecipeController : ControllerBase{
    private readonly RecipeService recipeService;
    private readonly IngredientService ingredientService;
    private readonly Auth0Provider auth;
    public RecipeController(Auth0Provider auth, RecipeService recipeService, IngredientService ingredientService){
        this.auth = auth;
        this.recipeService = recipeService;
        this.ingredientService = ingredientService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipes>> CreateRecipe([FromBody] Recipes recipeData){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
            Recipes recipe = recipeService.CreateRecipe(recipeData);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<Recipes>> GetRecipes(){
        try
        {
        List<Recipes> recipes = recipeService.GetRecipes();
        return Ok(recipes);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{recipeId}")]
    public ActionResult<Recipes> GetRecipeById(int recipeId){
        try
        {
            Recipes recipes = recipeService.GetRecipeById(recipeId);
            return Ok(recipes);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{recipeId}")]
    [Authorize]
    public ActionResult<Recipes> EditRecipe([FromBody] Recipes updateData, int recipeId){
        try
        {
            updateData.Id = recipeId;
            Recipes newRecipes = recipeService.EditRecipe(updateData, recipeId);
            return Ok(newRecipes);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{recipeId}")]
    [Authorize]
    public async Task<ActionResult<string>> RemoveRecipe(int recipeId){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            string message = recipeService.RemoveRecipe(recipeId, userInfo.Id);
            return Ok(message);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{recipeId}/ingredients")]
    public ActionResult<List<Ingredient>> GetIngredientById(int recipeId){
        try
        {
            List<Ingredient> ingredients = ingredientService.GetIngredientById(recipeId);
            return Ok(ingredients);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{query}/category")]
    [Authorize]

    public ActionResult<List<Recipes>> GetRecipeByQuery(string query){
        try
        {
            List<Recipes> recipe = recipeService.GetRecipeByQuery(query);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }
}