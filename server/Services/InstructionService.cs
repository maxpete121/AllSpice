namespace RecipeApp.Services;

public class InstructionService(InstructionRepository repo){
    private readonly InstructionRepository repo = repo;

    internal Instruction CreateNewInstruction(Instruction instructionData){
        Instruction instruction = repo.CreateNewInstruction(instructionData);
        return instruction;
    }
}