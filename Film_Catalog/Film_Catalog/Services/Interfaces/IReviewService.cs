using Film_Catalog.Models.DTO;

namespace Film_Catalog.Services.Interfaces
{
    public interface IReviewService
    {
        bool IsAllowedJwtToken(string JwtUserToken);
        Task SaveReview(ReviewModifyModel model, string UserId, Guid MovieId);
        Task ChangeReview(ReviewModifyModel model, Guid ReviewId, Guid MovieId);
        Task RemoveReview(Guid ReviewId, Guid MovieId);
    }
}
