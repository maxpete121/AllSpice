namespace RecipeApp.Services;


public class RecipeService(RecipeRepository repo){
    private readonly RecipeRepository repo = repo;

    internal Recipe CreateRecipe(Recipe recipeData){
        Recipe recipe = repo.CreateRecipe(recipeData);
        return recipe;
    }
}