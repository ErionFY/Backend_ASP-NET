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
                return StatusCode(401,"Invalid Token");
            }
            return _UserService.ProfileOfUser(User.Identity.Name);
            
        }

        [HttpPut]
        [Authorize]
        public ActionResult PutProfile(ProfileModel model) {
            if (!_UserService.IsAllowedJwtToken(Request.Headers.Authorization))
            {
                return StatusCode(401, "Invalid Token");
            }
            if (!ModelState.IsValid)
            {
                return StatusCode(401, "Model is incorrect");
            }
            if(!_UserService.IsEmailFree(model))
            {
                return StatusCode(400, "This Email is already taken");
            }
            _UserService.ChangeUserInfo(model);
            return Ok();
        }
    }
}
