namespace RecipeApp.Services;


public class IngredientService(IngredientRepository repo){
    private readonly IngredientRepository repo = repo;

    internal Ingredient CreateIngredient(Ingredient ingredientData){
        Ingredient ingredient = repo.CreateIngredient(ingredientData);
        return ingredient;
    }
}