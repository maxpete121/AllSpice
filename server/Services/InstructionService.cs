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

    internal Instruction GetInstructionById(int instructionId){
        Instruction instruction = repo.GetInstructionById(instructionId);
        return instruction;
    }

    internal string DeleteInstruction(int instructionId, string userId){
        Instruction instruction = GetInstructionById(instructionId);
        if(instruction.CreatorId == userId){
        List<Instruction> allInstructions = GetInstructionsByRecipe(instruction.RecipeId);
        repo.DeleteInstruction(instructionId);
        int currentStep = 0;
        for (int i = 0; i < allInstructions.Count; i++){
          allInstructions[i].Step = currentStep += 1;
          Instruction toUpdate = allInstructions[i];
          repo.UpdateInstructionStep(toUpdate);
        }
        string message = $"Step {instruction.Step} was removed";
        return message;
        }else{throw new Exception("You are not authorized to delete this.");}
    }
}