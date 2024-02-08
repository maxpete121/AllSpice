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

    internal Recipes GetRecipeById(int recipeId){
        Recipes recipes = repo.GetRecipeById(recipeId);
        return recipes;
    }

    internal Recipes EditRecipe(Recipes updateData, int recipeId){
        Recipes originalRecipe = GetRecipeById(recipeId);
        originalRecipe.Title ??= updateData.Title;
        originalRecipe.Instructions ??= updateData.Instructions;
        originalRecipe.Img ??= updateData.Img;
        originalRecipe.Category ??= updateData.Category;
        Recipes newRecipe = repo.EditRecipe(originalRecipe);
        return newRecipe;
    }
}