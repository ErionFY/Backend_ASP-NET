using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Film_Catalog.Models.DTO;

namespace Film_Catalog.Controllers
{
    [Route("api/account/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public void PostRegister(UserRegisterModel model)
        {
            
        }

        [HttpPost("login")]
        public void PostLogin(LoginCredentials model)
        {

        }


        [HttpPost("logout")]
        public void PostLogout()
        {

        }

    }
}
