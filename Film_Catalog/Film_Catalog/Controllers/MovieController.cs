using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Film_Catalog.Models;

namespace Film_Catalog.Controllers
{
    [Route("api/movies/")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet("{page}")]
        public MoviesPagedListModel GetPage(Int32 page=1)
        {
            return null;
        }

        [HttpGet("details/{id}")]
        public MovieDetailsModel GetDetails(Guid id)
        {
            return null;
        }
    }
}
