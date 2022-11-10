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
        public async Task<IActionResult> AddReview(ReviewModifyModel model, Guid movieId)
        {
            if (!_ReviewService.IsAllowedJwtToken(Request.Headers.Authorization))
            {
                return StatusCode(498);
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is incorrect");
            }
            try
            {
                await _ReviewService.SaveReview(model, User.Identity.Name, movieId);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

            [HttpPut("{id}/edit")]
            [Authorize]
            public async Task<IActionResult> EditReview(Guid movieId, Guid id, ReviewModifyModel model) {
            if (!_ReviewService.IsAllowedJwtToken(Request.Headers.Authorization))
            {
                return StatusCode(498, "Invalid Token");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is incorrect");
            }
            try
            {
                await _ReviewService.ChangeReview(model, id, movieId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

            [HttpDelete("{id}/delete")]
            [Authorize]
            public async Task<IActionResult> DeleteReview(Guid movieId, Guid id) {
            if (!_ReviewService.IsAllowedJwtToken(Request.Headers.Authorization))
            {
                return StatusCode(498);
            }

            try
            {
                await _ReviewService.RemoveReview( id, movieId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        }
    } 
