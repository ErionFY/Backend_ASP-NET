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
                return StatusCode(401, "Invalid Token");
            }
            try
            {
                _FavoriteMoviesService.GetFavoriteFilms(Request.Headers.Authorization);
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("favorites/{id}/add")]
        [Authorize]
        public void AddFavorites(Guid id) { }

        [HttpDelete("favorites/{id}/delete")]
        [Authorize]
        public void DeleteFavorites(Guid id) { }
        
    }
}
