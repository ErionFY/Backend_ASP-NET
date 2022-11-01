using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Film_Catalog.Models;

namespace Film_Catalog.Controllers
{
    [Route("api/favorites")]
    [ApiController]
    public class FavoriteMoviesController : ControllerBase
    {
        [HttpGet]
        public MoviesListModel GetFavorites() {
            return null;
        }

        [HttpPost("/{id}/add")]
        public void AddFavorites(Guid id) { }

        [HttpDelete("/{id}/delete")]
        public void DeleteFavorites(Guid id) { }
        
    }
}
