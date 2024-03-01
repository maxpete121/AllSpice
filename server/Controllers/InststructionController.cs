namespace RecipeApp.Controllers;

public class InstructionController : ControllerBase{
    private readonly InstructionService instructionService;
    private readonly Auth0Provider auth;
    
    public InstructionController(Auth0Provider auth, InstructionService instructionService){
        this.auth = auth;
        this.instructionService = instructionService;
    }

    public async Task<ActionResult<Instruction>>
}