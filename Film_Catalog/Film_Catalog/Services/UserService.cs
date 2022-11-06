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
            JwtUserToken = JwtUserToken.Substring(7, JwtUserToken.Length - 7);
            return !(_context.JwtLoggedOutTokens.Any(x => x.Token.Equals(JwtUserToken)));
        }

        public ProfileModel ProfileOfUser(string UserId)
        {

           var User= _context.Users.Find(new Guid(UserId));

            ProfileModel profileModel = new ProfileModel()
            {
                id = User.User_Id,
                nickName = User.UserName,
                email = User.Email,
                avatarLink = User.AvatarLink,
                name = User.Name,
                birthDate = User.BirthDate,
                gender = (Gender)User.Gender
           };
            return profileModel;
        }
        
        public bool IsEmailFree(ProfileModel model) //true -free
        {
            var User = _context.Users.Find(model.id);
            if (User.Email == model.email) { return true; }
            return !(_context.Users.Any(u => u.Email.Equals(model.email)));
        }
        public async Task ChangeUserInfo(ProfileModel model)
        {
            var User = _context.Users.Find(model.id);
            if (User != null)
            {
                User.Email = model.email;
                User.AvatarLink = model.avatarLink;
                User.Name = model.name;
                User.BirthDate = model.birthDate;
                User.Gender = (Int32)model.gender;

                await _context.SaveChangesAsync();
            }
        }
    }
}
