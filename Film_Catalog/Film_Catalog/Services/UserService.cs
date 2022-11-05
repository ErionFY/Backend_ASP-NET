using Film_Catalog.Models.DTO;
using Film_Catalog.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Film_Catalog.Services
{
    public class UserService:IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool IsAllowedJwtToken(string JwtUserToken)
        {
            return !(_context.JwtLoggedOutTokens.Any(x => x.Token.Equals(JwtUserToken)));
        }

        public ProfileModel ProfileOfUser(string UserId)
        {

            _context.Users.Find(UserId);
            ProfileModel profileModel = new ProfileModel()
            {
                id = " ",
                nickName = "",
                email = "",
                avatarLink = "",
                name = "",
                birthDate = "",
                gender = 1
           };
        }

    }
}
