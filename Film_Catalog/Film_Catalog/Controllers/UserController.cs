using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Film_Catalog.Controllers
{
    [Route("api/account/profile")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public void GetProfile() { }
        [HttpPut]
        public void PutProfile() { }
    }
}
