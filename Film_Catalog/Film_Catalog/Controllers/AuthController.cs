using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Film_Catalog.Models.DTO;
using Film_Catalog.Models.DBClasses;
using System.Web.Helpers;
using Film_Catalog.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;

namespace Film_Catalog.Controllers
{
    [Route("api/account/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _AuthService;

        public AuthController(IAuthService authService)
        {
            _AuthService = authService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> PostRegister(UserRegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(401, "Model is incorrect");
                
            }

            if (!_AuthService.CheckUique(model))
            {
                return StatusCode(400, "There is already a user with this username or email");
            } 

                try
               {
                   await _AuthService.AddUser(model);
                   return Ok();

               }
               catch(Exception e)
               {
                   
                   return StatusCode(500, "Errors during adding new User");
               }
      
        }

        [HttpPost("login")]
        public async Task<IActionResult> PostLogin(LoginCredentials model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(401, "Model is incorrect");
            }

            var identity = _AuthService.GetIdentity(model.username, model.password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(issuer: JwtConfigurations.Issuer,
                                           audience: JwtConfigurations.Audience,
                                           notBefore: now,
                                           claims: identity.Claims,
                                           expires: now.Add(new TimeSpan(0, JwtConfigurations.Lifetime,0)),
                                           signingCredentials: new SigningCredentials(JwtConfigurations.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return new JsonResult(response);
            
        }


        [HttpPost("logout")]
        [Authorize]
        public void PostLogout()
        {
            _AuthService.LogOutJWT(Request.Headers.Authorization);
        }

    }
}
