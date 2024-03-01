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
        accounts.*
        FROM instruction
        JOIN accounts ON instruction.creatorId = accounts.id
        WHERE instruction.id = LAST_INSERT_ID()
        ";
        Instruction instruction = db.Query<Instruction, Account, Instruction>(sql, (instructions, account)=>{
            instructions.Creator = account;
            return instructions;
        }, instructionData).FirstOrDefault();
        return instruction;
    }

    internal List<Instruction> GetInstructionsByRecipe(int recipeId){
        string sql = @"
        SELECT
        instruction.*,
        accounts.*
        FROM instruction
        JOIN accounts ON instruction.creatorId = accounts.id
        WHERE instruction.recipeId = @recipeId
        ";
        List<Instruction> instructions = db.Query<Instruction, Account, Instruction>(sql, (instructions, account)=>{
            instructions.Creator = account;
            return instructions;
        }, new{recipeId}).ToList();
        return instructions;
    }

    internal Instruction GetInstructionById(int instructionId){
        string sql = @"
        SELECT
        instruction.*,
        accounts.*
        FROM instruction
        JOIN accounts ON instruction.creatorId = accounts.id
        WHERE instruction.id = @instructionId
        ";
        Instruction instruction = db.Query<Instruction, Account, Instruction>(sql, (instruction, account)=>{
            instruction.Creator = account;
            return instruction;
        }, new{instructionId}).FirstOrDefault();
        return instruction;
    }

    internal void DeleteInstruction(int instructionId){
        string sql = @"
        DELETE FROM instruction
        WHERE id = @instructionId";
        db.Execute(sql, new{instructionId});
    }

    internal void UpdateInstructionStep(Instruction instructionData){
        string sql = @"
        UPDATE instruction SET
        step = @step
        WHERE id = @id;
        ";
        db.Execute(sql, instructionData);
    }
}