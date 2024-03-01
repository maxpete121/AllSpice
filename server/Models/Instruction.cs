namespace RecipeApp.Models;


public class Instruction : RepoItem<int>{
    public string Body {get; set;}
    public int Step {get; set;}
    public int RecipeId {get; set;}
    public string CreatorId {get; set;}
    public Account Creator {get; set;}
}