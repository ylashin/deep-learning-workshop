using MovieLensRecommender.Models;
using MovieLensRecommender.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MovieLensRecommender.Controllers
{
    public class MoviesController : ApiController
    {
        [HttpGet]
        [Route("api/movies")]
        public IList<Movie> Get()
        {
            return WebApiApplication.Movies;
        }

        [HttpGet]
        [Route("api/movies/users/min-rating/{minRatings}")]
        public IList<User> GetUsersWithMinimumNumberOfRatings(int minRatings)
        {
            var topMovies = WebApiApplication.TopMovies.Select(a => a.Id).ToList();
            return WebApiApplication.Ratings.Where(a => topMovies.Contains(a.MovieId))
                .GroupBy(a => a.UserId)
                .Select(a => new User
                {
                    UserId = a.Key,
                    RatingCount = a.ToList().Count
                }).Where(a => a.RatingCount >= minRatings)
                .OrderBy(a => a.RatingCount)
                .ToList();
        }


        [HttpGet]
        [Route("api/movies/users/ratings/{userId}")]
        public IList<RatingDto> GetTopMovieRatingsForUser(int userId)
        {
            var topMovies = WebApiApplication.TopMovies.Select(a => a.Id).ToList();

            return WebApiApplication
                .TopMovies
                .Select(a => {
                    var key = userId + "#" + a.Id;
                    int? rating = null;
                    if (WebApiApplication.RatingLookup.ContainsKey(key))
                        rating = WebApiApplication.RatingLookup[key];
                    return new RatingDto
                    {
                        MovieId = a.Id,
                        Rating = rating,
                        Title = a.Title
                    };

                })
                .OrderByDescending(a => a.Rating)
                .ToList();       
        }

        [Route("api/movies/predict/{movieId}/{userId}")]
        public float GetTopMovieRatingsForUser(int movieId, int userId)
        {
            Predictor p = new Predictor();
            return p.PredicRating(WebApiApplication.User2Index[userId], WebApiApplication.Movie2Index[movieId]);
        }        
    }
}
