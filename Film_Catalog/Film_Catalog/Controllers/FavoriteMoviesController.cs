using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Film_Catalog.Controllers
{
    [Route("api/favorites")]
    [ApiController]
    public class FavoriteMoviesController : ControllerBase
    {
        [HttpGet]
        public void GetFavorites() { }

        [HttpPost("/{id}/add")]
        public void AddFavorites(Guid id) { }

        [HttpDelete("/{id}/delete")]
        public void DeleteFavorites(Guid id) { }
        
    }
}
