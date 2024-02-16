namespace RecipeApp.Controllers;

[ApiController]
[Route("api/reviews")]

public class ReviewsController : ControllerBase{
    private readonly ReviewsService reviewsService;
    private readonly Auth0Provider auth;
    public ReviewsController(Auth0Provider auth,ReviewsService reviewsService){
        this.auth = auth;
        this.reviewsService = reviewsService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Reviews>> CreateReview([FromBody] Reviews reviewData){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            reviewData.AccountId = userInfo.Id;
            Reviews reviews = reviewsService.CreateReview(reviewData, userInfo.Id);
            return Ok(reviews);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }

    // [HttpGet("{recipeId}")]
    // public ActionResult<List<Reviews>> GetRecipeReviews(int recipeId){
    //     try
    //     {
    //     List<Reviews> reviews = reviewsService  
    //     }
    //     catch (Exception error)
    //     {
            
    //         return BadRequest(error.Message);
    //     }
    // }
}


