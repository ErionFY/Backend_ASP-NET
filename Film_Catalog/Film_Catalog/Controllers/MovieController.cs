using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Film_Catalog.Models.DTO;
using Film_Catalog.Services.Interfaces;

namespace Film_Catalog.Controllers
{
    [Route("api/movies/")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _MovieService;

        public MovieController(IMovieService movieService)
        {
            _MovieService = movieService;
        }

        [HttpGet("{page}")]
        public ActionResult<MoviesPagedListModel> GetPage(Int32 page=1)
        {
            if (page < 1)
            {
                return StatusCode(404);
            }
            try
            {
                return _MovieService.GetListModel(page);
            }
            catch
            {
                return StatusCode(500);
            }

            
        }

        [HttpGet("details/{id}")]
        public ActionResult<MovieDetailsModel> GetDetails(Guid id)
        {
            try
            {
               return _MovieService.GetMovieDetails(id);
            }
            catch()
            {
                return StatusCode(500);
            }
        }
    }
}
