using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Film_Catalog.Models.DTO;

namespace Film_Catalog.Controllers
{
    [Route("api/movie/{movieId}/review/")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        [HttpPost("add")]
        public void AddReview(ReviewModifyModel model,Guid movieId) { }
        [HttpPut("{id}/edit")]
        public void EditReview(Guid movieId,Guid id,ReviewModifyModel model) { }
        [HttpDelete("{id}/delete")]
        public void DeleteReview(Guid movieId,Guid id ) { }
    }
}
