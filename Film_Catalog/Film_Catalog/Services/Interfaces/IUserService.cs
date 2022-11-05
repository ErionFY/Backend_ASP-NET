using Film_Catalog.Models.DTO;

namespace Film_Catalog.Services.Interfaces
{
    public interface IUserService
    {
        bool IsAllowedJwtToken(string JwtUserToken);
        ProfileModel ProfileOfUser(string UserId);
    }
}
