using Film_Catalog.Models.DTO;

namespace Film_Catalog.Services.Interfaces
{
    public interface IFavoriteMoviesService
    {
        bool IsAllowedJwtToken(string JwtUserToken);
        MoviesListModel GetFavoriteFilms(string User_Id);
    }
}
