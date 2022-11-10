using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Film_Catalog.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Film_Catalog.Services.Interfaces;

namespace Film_Catalog.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FavoriteMoviesController : ControllerBase
    {
        private IFavoriteMoviesService _FavoriteMoviesService;

        public FavoriteMoviesController(IFavoriteMoviesService favoriteMoviesService)
        {
            _FavoriteMoviesService = favoriteMoviesService;
        }

        [HttpGet("favorites")]
        [Authorize]
        public ActionResult<MoviesListModel> GetFavorites() {
            if (!_FavoriteMoviesService.IsAllowedJwtToken(Request.Headers.Authorization))
            {
                return StatusCode(498);
            }
            try
            {
               return _FavoriteMoviesService.GetFavoriteFilms(User.Identity.Name);
                
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("favorites/{id}/add")]
        [Authorize]
        public async Task<IActionResult> AddFavorites(Guid id) {
            if (!_FavoriteMoviesService.IsAllowedJwtToken(Request.Headers.Authorization))
            {
                return StatusCode(498);
            }
            try
            {
                await _FavoriteMoviesService.AddFavoriteFilm(id, User.Identity.Name);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("favorites/{id}/delete")]
        [Authorize]
        public async Task<IActionResult> DeleteFavorites(Guid id) {
            if (!_FavoriteMoviesService.IsAllowedJwtToken(Request.Headers.Authorization))
            {
                return StatusCode(498);
            }
            try
            {
                await _FavoriteMoviesService.DeleteFavoriteFilm(id, User.Identity.Name);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        
    }
}
