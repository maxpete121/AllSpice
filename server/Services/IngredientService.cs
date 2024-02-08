namespace RecipeApp.Services;


public class IngredientService(IngredientRepository repo){
    private readonly IngredientRepository repo = repo;

    internal Ingredient CreateIngredient(Ingredient ingredientData){
        Ingredient ingredient = repo.CreateIngredient(ingredientData);
        return ingredient;
    }

    internal List<Ingredient> GetIngredientById(int recipeId){
        List<Ingredient> ingredients = repo.GetIngredientById(recipeId);
        if(ingredients == null) throw new Exception("No ingredient found...");
        return ingredients;
    }

    internal string DeleteIngredient(int ingredientId){
        repo.DeleteIngredient(ingredientId);
        return "Ingredient Removed";
    }
}