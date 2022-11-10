using Film_Catalog.Models.DBClasses;
using Film_Catalog.Models.DTO;
using Film_Catalog.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Film_Catalog.Services
{
    public class MovieService:IMovieService
    {
        private readonly  ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public MovieDetailsModel GetMovieDetails(Guid movie_id)
        {
            var movie = _context.Movies.Find(movie_id);
            ICollection<Review> reviews=_context.Reviews.Include(r=>r.Author).Where(u=>u.Movie.Movie_Id == movie_id).ToList();
            ICollection<Genre> genres = _context.Genres.Where(g => g.Movies.Any(m => m.Movie_Id == movie_id)).ToList();

            ICollection<GenreModel> genresModels=new List<GenreModel>();
            ICollection<ReviewModel> reviewsModels=new List<ReviewModel>();

            foreach (Genre g in genres)
            {
                genresModels.Add(new GenreModel { 
                    id = g.Genre_Id,
                    name = g.Name 
                });
            }
            foreach(Review r in reviews)
            {
                

                reviewsModels.Add(new ReviewModel
                {
                    id = r.Review_Id,
                    rating=r.Rating,
                    reviewText=r.ReviewText,
                    isAnonymous=r.IsAnonymous,
                    createDateTime=r.CreateDateTime,
                    author=new UserShortModel
                    {
                        userId=r.Author.User_Id,
                        nickName=r.Author.Name,
                        avatar=r.Author.AvatarLink
                    }
                });
            }

            return new MovieDetailsModel {
            id = movie_id,
            name=movie.Name,
            poster=movie.Poster,
            year= (int)movie.Year,
            country=movie.country,
           genres= genresModels,
          reviews= reviewsModels,
            time=movie.Time,
            tagline=movie.Tagline,
            description=movie.Description,
            director=movie.Director,
            budget=movie.Budget,
            fees=movie.Fees,
            ageLimit=movie.AgeLimit
            };
        }




        public MoviesPagedListModel GetListModel(Int32 page)
        {
            Int32 pageSize = 5;
            
            Int32 MoviesCount = _context.Movies.Count();
            PageInfoModel pageInfoModel = new PageInfoModel
            {
                pageSize=5,
                pageCount= (int)Math.Ceiling((double)MoviesCount/ pageSize),
                currentPage= pageSize
            };
       
            ICollection<MovieElementModel> movieElementModels = new List<MovieElementModel>();
            var movies=_context.Movies.Include(m=>m.Genres).Include(m=>m.Reviews).Skip(pageSize*(page-1)).Take(pageSize).ToList();

            ICollection<GenreModel> genreModels = new List<GenreModel>();
            ICollection<ReviewShortModel> reviewsModels = new List<ReviewShortModel>();
            foreach( Movie  m in movies)
            {
                genreModels.Clear();
                reviewsModels.Clear();

                foreach ( Genre g in m.Genres)
                {
                    genreModels.Add(new GenreModel
                    {
                        id=g.Genre_Id,
                        name=g.Name
                    });
                }

                foreach(Review r in m.Reviews)
                {
                    reviewsModels.Add(new ReviewShortModel
                    {
                        id =r.Review_Id,
                        rating=r.Rating,
                    });
                }

                movieElementModels.Add(new MovieElementModel
                {
                   id=m.Movie_Id,
                   name=m.Name,
                   poster=m.Poster,
                   year= (int)m.Year,
                   country=m.country,
                   genres= genreModels,
                   reviews= reviewsModels

                });

            }

            MoviesPagedListModel moviesPagedListModel = new MoviesPagedListModel
            {
                pageInfo = pageInfoModel,
                movies = movieElementModels
            };
            return moviesPagedListModel;
        }

    }
}
