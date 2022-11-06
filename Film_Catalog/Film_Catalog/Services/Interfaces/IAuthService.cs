using Film_Catalog.Models.DTO;
using System.Security.Claims;

namespace Film_Catalog.Services.Interfaces
{
    public interface IAuthService
    {
        bool CheckUique(UserRegisterModel model);
        Task AddUser(UserRegisterModel model);
        ClaimsIdentity GetIdentity(string username, string password);
        Task LogOutJWT(string JwtUserToken);
        bool IsAllowedJwtToken(string JwtUserToken);
    }
}
