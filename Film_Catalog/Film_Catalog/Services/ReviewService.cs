using Film_Catalog.Models.DBClasses;
using Film_Catalog.Models.DTO;
using Film_Catalog.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Film_Catalog.Services
{
    public class ReviewService: IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool IsAllowedJwtToken(string JwtUserToken)
        {
            JwtUserToken = JwtUserToken.Substring(7, JwtUserToken.Length - 7);
            return !(_context.JwtLoggedOutTokens.Any(x => x.Token.Equals(JwtUserToken)));
        }
        public async Task SaveReview(ReviewModifyModel model,string UserId,Guid MovieId)
        {
           
            Movie movie = _context.Movies.Find(MovieId);
            User user = _context.Users.Find(new Guid(UserId));
            
            Review review= new Review
            {   
               
                Rating = model.rating,
                ReviewText=model.reviewText,
                IsAnonymous=model.isAnonymous,
                CreateDateTime= DateTime.UtcNow,
                Movie= movie,
               Author=user
            } ;
          
            await _context.AddAsync(review);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeReview(ReviewModifyModel model, Guid ReviewId, Guid MovieId)
        {
            Review review =_context.Reviews.Find(ReviewId);
            if (review != null)
            {
                review.ReviewText = model.reviewText;
                review.IsAnonymous = model.isAnonymous;
                review.Rating=model.rating;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveReview(Guid ReviewId, Guid MovieId)
        {
            Review review= _context.Reviews.Find(ReviewId);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}
