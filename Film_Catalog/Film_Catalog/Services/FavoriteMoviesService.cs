using Film_Catalog.Models.DBClasses;
using Film_Catalog.Models.DTO;
using Film_Catalog.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            Guid User_id = new Guid(User_Id);
            var movies = _context.Movies.Include(g=>g.Genres).Include(r=>r.Reviews).Where(m=>m.Users.Any(m=>m.User_Id== User_id)).ToList();
            ICollection<MovieElementModel> movieElementModels = new List<MovieElementModel>();
            
                ICollection<GenreModel> genreModels = new List<GenreModel>();
                ICollection<ReviewShortModel> reviewsModels = new List<ReviewShortModel>();
                foreach (Movie m in movies)
                {
                    reviewsModels.Clear();
                    genreModels.Clear();

                    foreach (Genre g in m.Genres)
                    {
                        genreModels.Add(new GenreModel
                        {
                            id = g.Genre_Id,
                            name = g.Name
                        });
                    }

                    foreach (Review r in m.Reviews)
                    {
                        reviewsModels.Add(new ReviewShortModel
                        {
                            id = r.Review_Id,
                            rating = r.Rating,
                        });
                    }

                    movieElementModels.Add(new MovieElementModel
                    {
                        id = m.Movie_Id,
                        name = m.Name,
                        poster = m.Poster,
                        year = (int)m.Year,
                        country = m.country,
                        genres = genreModels,
                        reviews = reviewsModels
                    });

                }
            
            return new MoviesListModel { movies = movieElementModels };
        }

        public async Task AddFavoriteFilm(Guid Movie_Id, string User_Id)
        {
            User user = _context.Users.Include(m=>m.Movies).First(u=>u.User_Id.Equals(new Guid(User_Id)));
        
           foreach(Movie m in user.Movies)
            {
                if (m.Movie_Id==Movie_Id) { return; }
            }

            var movie = _context.Movies.Include(m=>m.Users).First(r=>r.Movie_Id== Movie_Id);

            if (movie == null) { return; }
                movie.Users.Add(user);
                await _context.SaveChangesAsync();
            
            
        }

        public async Task DeleteFavoriteFilm(Guid Movie_Id, string User_Id)
        {
            User user = _context.Users.Include(m => m.Movies).First(u => u.User_Id.Equals(new Guid(User_Id)));

            int count = 0;
            foreach (Movie m in user.Movies)
            {
                if (m.Movie_Id == Movie_Id) { count++; }
            }
            if(count==0) { return; }

            var movie = _context.Movies.Include(m => m.Users).First(r => r.Movie_Id == Movie_Id);

            if (movie == null) { return; }
            movie.Users.Remove(user);
            await _context.SaveChangesAsync();


        }
    }
}
