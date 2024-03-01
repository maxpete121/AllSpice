namespace RecipeApp.Repositories;


public class InstructionRepository(IDbConnection db){
    private readonly IDbConnection db = db;

    internal Instruction CreateNewInstruction(Instruction instructionData){
        string sql = @"
        INSERT INTO instruction
        (body, step, recipeId, creatorId)
        VALUES
        (@body, @step, @recipeId, @creatorId);

        SELECT
        instruction.*,
        recipes.*,
        accounts.*
        JOIN recipes ON instruction.recipeId = recipes.id
        JOIN accounts ON instruction.creatorId = accounts.id
        WHERE instruction.id = LAST_INSERT_ID();
        ";
        Instruction instruction = db.Query<Instruction, Recipes, Account, Instruction>(sql, (instructions, recipe, account)=>{
            instructions.Creator = account;
            return instructions;
        }, instructionData).FirstOrDefault();
        return instruction;
    }
}