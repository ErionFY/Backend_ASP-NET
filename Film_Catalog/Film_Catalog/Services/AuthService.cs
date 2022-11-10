using Film_Catalog.Models.DBClasses;
using Film_Catalog.Models.DTO;
using Film_Catalog.Services.Interfaces;
using System.Security.Claims;
using System.Text;
using System.Web.Helpers;

namespace Film_Catalog.Services
{
    public class AuthService:IAuthService
    {

        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CheckUique(UserRegisterModel model)
        {
            return !(_context.Users.Any(o => o.Email.Equals(model.email)) || _context.Users.Any(u => u.UserName.Equals(model.userName)));
        }
        public async Task AddUser(UserRegisterModel model)
        {
            if (model.birthDate == null) { model.birthDate = DateTime.Now; }
            await _context.Users.AddAsync(new User
            {
                UserName = model.userName,
                Name = model.name,
                Email = model.email,
                Password = sha256(model.password),
                BirthDate = (DateTime)model.birthDate,
                Gender = (int?)model.gender,
                IsAdmin = false
            }) ;
            await _context.SaveChangesAsync();
        }

        private string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    
        public ClaimsIdentity GetIdentity(string username, string password)
        {
            password = sha256(password);
            var user = _context.Users.FirstOrDefault(x => x.UserName.Equals(username) && x.Password.Equals(password));
            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.User_Id.ToString()),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.IsAdmin.ToString())

        };

            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
        public bool IsAllowedJwtToken(string JwtUserToken)
        {
            JwtUserToken = JwtUserToken.Substring(7, JwtUserToken.Length - 7);
            return !(_context.JwtLoggedOutTokens.Any(x => x.Token.Equals(JwtUserToken)));
        }
        public async Task LogOutJWT(string JwtUserToken)
        {
            JwtUserToken = JwtUserToken.Substring(7, JwtUserToken.Length-7);
            await _context.JwtLoggedOutTokens.AddAsync(new JwtLoggedOutToken
            {
                Token = JwtUserToken
            }
            ) ;
            await _context.SaveChangesAsync();
            
        }
    }

}

