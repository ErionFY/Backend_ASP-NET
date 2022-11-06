using Film_Catalog.Models.DTO;
using Film_Catalog.Services.Interfaces;

namespace Film_Catalog.Services
{
    public class FavoriteMoviesService: IFavoriteMoviesService
    {
        private readonly ApplicationDbContext _context;

        public FavoriteMoviesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool IsAllowedJwtToken(string JwtUserToken)
        {
            JwtUserToken = JwtUserToken.Substring(7, JwtUserToken.Length - 7);
            return !(_context.JwtLoggedOutTokens.Any(x => x.Token.Equals(JwtUserToken)));
        }
        public MoviesListModel GetFavoriteFilms(string User_Id)
        {
            MoviesListModel model = new MoviesListModel();





            return model;
        }
    }
}
