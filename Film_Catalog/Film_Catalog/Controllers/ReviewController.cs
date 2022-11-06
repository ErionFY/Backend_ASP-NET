using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Film_Catalog.Models.DTO;
using Film_Catalog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Film_Catalog.Controllers
{
    [Route("api/movie/{movieId}/review/")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private IReviewService _ReviewService;

        public ReviewController(IReviewService reviewService)
        {
            _ReviewService = reviewService;
        }

        [HttpPost("add")]
        [Authorize]
        public ActionResult AddReview(ReviewModifyModel model, Guid movieId)
        {
            if (!_ReviewService.IsAllowedJwtToken(Request.Headers.Authorization))
            {
                return StatusCode(401, "Invalid Token");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(401, "Model is incorrect");
            }
            try
            {
                _ReviewService.SaveReview(model, User.Identity.Name, movieId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

            [HttpPut("{id}/edit")]
            [Authorize]
            public ActionResult EditReview(Guid movieId, Guid id, ReviewModifyModel model) {
            if (!_ReviewService.IsAllowedJwtToken(Request.Headers.Authorization))
            {
                return StatusCode(401, "Invalid Token");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(401, "Model is incorrect");
            }
            try
            {
                _ReviewService.ChangeReview(model, id, movieId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

            [HttpDelete("{id}/delete")]
            [Authorize]
            public ActionResult DeleteReview(Guid movieId, Guid id) {
            if (!_ReviewService.IsAllowedJwtToken(Request.Headers.Authorization))
            {
                return StatusCode(401, "Invalid Token");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(401, "Model is incorrect");
            }
            try
            {
                _ReviewService.RemoveReview( id, movieId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        }
    } 
