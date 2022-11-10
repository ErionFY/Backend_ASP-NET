using Film_Catalog.Models.DTO;

namespace Film_Catalog.Services.Interfaces
{
    public interface IMovieService
    {
        MovieDetailsModel GetMovieDetails(Guid movie_id);
        public MoviesPagedListModel GetListModel(Int32 page);
    }
}
