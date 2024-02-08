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
        originalRecipe.Title = updateData.Title?.Length > 0 ? updateData.Title : originalRecipe.Title;
        originalRecipe.Instructions = updateData.Instructions?.Length > 0 ? updateData.Instructions : originalRecipe.Instructions;
        originalRecipe.Img = updateData.Img?.Length > 0 ? updateData.Img : originalRecipe.Img;
        originalRecipe.Category = updateData.Category?.Length > 0 ? updateData.Category : originalRecipe.Category;
        Recipes newRecipe = repo.EditRecipe(originalRecipe);
        return newRecipe;
    }
}