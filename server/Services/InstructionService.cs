namespace RecipeApp.Services;

public class InstructionService(InstructionRepository repo){
    private readonly InstructionRepository repo = repo;

    internal Instruction CreateNewInstruction(Instruction instructionData, string userId){
        if(userId == null) throw new Exception("Please log in.");
        List<Instruction> currentInstructions = GetInstructionsByRecipe(instructionData.RecipeId);
        if(currentInstructions != null){
            int amount = currentInstructions.Count();
            instructionData.Step = amount += 1;
        }else{instructionData.Step = 1;}
        Instruction instruction = repo.CreateNewInstruction(instructionData);
        return instruction;
    }

    internal List<Instruction> GetInstructionsByRecipe(int recipeId){
        List<Instruction> instructions = repo.GetInstructionsByRecipe(recipeId);
        return instructions;
    }
}