namespace RecipeApp.Services;


public class RecipeService(RecipeRepository repo){
    private readonly RecipeRepository repo = repo;

    internal Recipes CreateRecipe(Recipes recipeData){
        Recipes recipe = repo.CreateRecipe(recipeData);
        return recipe;
    }

    internal List<Recipes> GetRecipes(){
        List<Recipes> recipes = repo.GetRecipes();
        return recipes;
    }
}