

export class Instruction{
    constructor(data){
        this.id = data.id
        this.body = data.body
        this.step = data.step 
        this.recipeId = data.recipeId
        this.creatorId = data.creatorId
        this.creator = data.creator
    }
}