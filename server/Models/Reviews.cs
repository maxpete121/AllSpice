namespace RecipeApp.Models;


public class Reviews : RepoItem<int>{
    public string Body {get; set;}
    public int Score {get; set;}
    public int RecipeId {get; set;}
    public string AccountId {get; set;}
    public Account Creator {get; set;}
}