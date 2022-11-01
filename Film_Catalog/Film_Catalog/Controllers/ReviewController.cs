using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Film_Catalog.Controllers
{
    [Route("api/movie/{movieId}/review/")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        [HttpPost("add")]
        public void AddReview() { }
        [HttpPut("{id}/edit")]
        public void EditReview(Guid id) { }
        [HttpDelete("{id}/delete")]
        public void DeleteReview(Guid id) { }
    }
}
