namespace RecipeApp.Repositories;


public class ReviewsRepository(IDbConnection db){
    private readonly IDbConnection db = db;


    internal Reviews CreateReview(Reviews reviewData){
        string sql = @"
        INSERT INTO reviews
        (body, score, recipeId, accountId)
        VALUES
        (@body, @score, @recipeId, @accountId)
        
        SELECT
        reviews.*,
        accounts.*
        FROM reviews
        JOIN accounts ON reviews.accountId = accounts.id
        WHERE reviews.id = LAST_INSERT_ID()";
        Reviews review = db.Query<Reviews, Account, Reviews>(sql, (review, account)=>{
            review.Creator = account;
            return review;
        }, reviewData).FirstOrDefault();
        return review;
    }

    internal List<Reviews> GetRecipeReviews(int recipeId){
        string sql =@"
        SELECT
        reviews.*,
        accounts.*
        FROM reviews
        JOIN accounts ON reviews.accountId = accounts.id
        WHERE reviews.recipeId = @recipeId";
        List<Reviews> reviews = db.Query<Reviews, Account, Reviews>(sql, (reviews, account)=>{
            reviews.Creator = account;
            return reviews;
        }, new{recipeId}).ToList();
        return reviews;
    }
}