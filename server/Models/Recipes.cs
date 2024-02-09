using postItSharp.Models;

namespace RecipeApp.Models;

public class Recipes : RepoItem<int>{
    public string Title {get; set;}
    public string Instructions {get; set;}
    public string Img {get; set;}
    public string Category{get; set;}
    public string CreatorId {get; set;}
    public Account Creator {get; set;}
}
public class FavoriteRecipe : Recipes{
  public int FavoriteId { get; set; }
}