using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Film_Catalog.Models.DTO;

namespace Film_Catalog.Controllers
{
    [Route("api/account/profile")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ProfileModel GetProfile() { return null; }
        [HttpPut]
        public void PutProfile(ProfileModel model) { }
    }
}
