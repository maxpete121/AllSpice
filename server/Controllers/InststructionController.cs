namespace RecipeApp.Controllers;

[ApiController]
[Route("api/ingredients")]
public class InstructionController : ControllerBase{
    private readonly InstructionService instructionService;
    private readonly Auth0Provider auth;
    
    public InstructionController(Auth0Provider auth, InstructionService instructionService){
        this.auth = auth;
        this.instructionService = instructionService;
    }
[HttpPost]
[Authorize]
    public async Task<ActionResult<Instruction>> CreateNewInstruction([FromBody]Instruction instructionData){
        try
        {
          Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
          Instruction instruction = instructionService.CreateNewInstruction(instructionData, userInfo.Id);
          return Ok(instruction);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{recipeId}/recipe")]
    public ActionResult<List<Instruction>> GetInstructionsByRecipe(int recipeId){
        try
        {
            List<Instruction> instruction = instructionService.GetInstructionsByRecipe(recipeId);
            return Ok(instruction);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }
}