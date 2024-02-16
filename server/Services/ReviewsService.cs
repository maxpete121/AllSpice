namespace RecipeApp.Services;

public class ReviewsService(ReviewsRepository repo){
    private readonly ReviewsRepository repo = repo;

    internal Reviews CreateReview(Reviews reviewData, string userId){
        if(userId != null){
        Reviews review = repo.CreateReview(reviewData);
        return review;
        }else{throw new Exception("Please log in to post a review");}
    }

    internal List<Reviews> GetRecipeReviews(int recipeId){
        List<Reviews> reviews = repo.GetRecipeReviews(recipeId);
        return reviews;
    }
}