


export class Recipes{
    constructor(data){
        this.title = data.title
        this.instructions = data.instructions
        this.img = data.img
        this.category = data.category
        this.creatorId = data.creatorId
        this.creator = data.creators
    }
}


// public int Id {get; set;}
// public string Title {get; set;}
// public string Instructions {get; set;}
// public string Img {get; set;}
// public string Category{get; set;}
// public string CreatorId {get; set;}
// public Account Creator {get; set;}