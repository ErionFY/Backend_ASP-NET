using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Film_Catalog.Controllers
{
    [Route("api/account/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public void PostRegister()
        {

        }

        [HttpPost("login")]
        public void PostLogin()
        {

        }


        [HttpPost("logout")]
        public void PostLogout()
        {

        }

    }
}
