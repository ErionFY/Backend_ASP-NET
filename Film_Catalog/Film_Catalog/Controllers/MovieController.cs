using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Film_Catalog.Controllers
{
    [Route("api/movies/")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet("{page}")]
        public void GetPage(Int32 page)
        {

        }

        [HttpGet("details/{id}")]
        public void GetDetails(Guid id)
        {

        }
    }
}
