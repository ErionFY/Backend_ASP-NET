using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Film_Catalog.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Film_Catalog.Services.Interfaces;

namespace Film_Catalog.Controllers
{
    

    [Route("api/account/profile")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserService _UserService;

        public UserController(IUserService userService)
        {
            _UserService = userService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<ProfileModel> GetProfile() {
            if(!_UserService.IsAllowedJwtToken(Request.Headers.Authorization)){
                return StatusCode(401," Please ReLogin");
            }
            return _UserService.ProfileOfUser(User.Identity.Name);
            
        }
        [HttpPut]
        [Authorize]
        public void PutProfile(ProfileModel model) {
        
        }
    }
}
