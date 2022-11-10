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
                return StatusCode(498);
            }
            return _UserService.ProfileOfUser(User.Identity.Name);
            
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> PutProfile(ProfileModel model) {
            if (!_UserService.IsAllowedJwtToken(Request.Headers.Authorization))
            {
                return StatusCode(498);
            }
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is incorrect");
            }
            if(!_UserService.IsEmailFree(model))
            {
                return StatusCode(400, "This Email is already taken");
            }
           await _UserService.ChangeUserInfo(model);
            return Ok();
        }
    }
}
