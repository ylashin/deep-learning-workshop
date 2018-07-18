using CsvHelper.Configuration;
using MovieLensRecommender.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MovieLensRecommender
{
    public class WebApiApplication : HttpApplication
    {
        public static readonly List<Movie> TopMovies;
        public static readonly List<Movie> Movies;
        public static readonly List<Rating> Ratings;
        public static readonly List<User> Users;
        public static readonly Dictionary<string, int> RatingLookup;

        public static readonly Dictionary<int, int> User2Index;
        public static readonly Dictionary<int, int> Movie2Index;

        private static string GetDataFilePath(string fileName)
        {
            return Path.Combine(HttpRuntime.AppDomainAppPath, $"data\\movie-lens\\{fileName}");
        }

        static WebApiApplication()
        {
            var moviesFilePath = GetDataFilePath("movies.csv");
            using (var file = File.OpenText(moviesFilePath))
            {               
                var csv = new CsvHelper.CsvReader(file);
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.MissingFieldFound = null;
                Movies = csv.GetRecords<Movie>().ToList();
            }

            var ratingsFilePath = GetDataFilePath("ratings.dat");
            using (var file = File.OpenText(ratingsFilePath))
            {
                var csv = new CsvHelper.CsvReader(file);
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.Delimiter = "::";
                Ratings = csv.GetRecords<Rating>().ToList();

                Users = Ratings.GroupBy(a => a.UserId)
                    .Select(a => new User {
                        UserId = a.Key,
                        RatingCount = a.ToList().Count
                    }).ToList();
            }

            var ratingCountMap = Ratings.GroupBy(a => a.MovieId)
                .Select(a => new { MovieId = a.Key, RatingCount = a.Count() })
                .ToDictionary(a => a.MovieId, a => a.RatingCount);

            var imageCardFiles = Directory
                .GetFiles(Path.Combine(HttpRuntime.AppDomainAppPath, @"data\images"))
                .Select(a => Path.GetFileName(a).ToLower())
                .ToDictionary(a => a);

            Movies.ForEach(a => {
                a.RatingCount = ratingCountMap.ContainsKey(a.Id) ? ratingCountMap[a.Id] : 0;
                a.CardImage = imageCardFiles.ContainsKey($"{a.Id}.jpg") ? imageCardFiles[$"{a.Id}.jpg"] : "nopicture.jpg";
            });

            TopMovies = Movies.OrderByDescending(a => a.RatingCount).Take(1000).ToList();
            RatingLookup = Ratings.ToDictionary(a => a.UserId +"#" +a.MovieId, a => a.RatingValue);

            moviesFilePath = GetDataFilePath("userid2index.csv");
            User2Index = File.ReadAllLines(moviesFilePath).ToList().Select(a => a.Split(','))
                .ToDictionary(a => int.Parse(a[0]), a => int.Parse(a[1]));

            moviesFilePath = GetDataFilePath("movieid2index.csv");
            Movie2Index = File.ReadAllLines(moviesFilePath).ToList().Select(a => a.Split(','))
                .ToDictionary(a => int.Parse(a[0]), a => int.Parse(a[1]));

        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
