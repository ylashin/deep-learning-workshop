using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace PosterCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://www.omdbapi.com/?apikey=4e220919&t=Star+Wars%3A+Episode+IV+-+A+New+Hope

            var path = @"C:\DL\MovieLensRecommender\MovieLensRecommender\data\movies.csv";
            using (var file = File.OpenText(path))
            {
                var csv = new CsvHelper.CsvReader(file);
                var movies = csv.GetRecords<Movie>()
                    .OrderByDescending(a => a.RatingCount)
                    .Take(1000)
                    .ToList();

                movies.ForEach(m => ProcessMovie(m));

            }
        }

        private static void ProcessMovie(Movie m)
        {
            var files = Directory.GetFiles(@"C:\DL\MovieLensRecommender\PosterCollector\bin\Debug\", $"{m.Id}.*");
            if (files.Any())
                return;

            var title = m.Title.Substring(0, m.Title.Length - 7);
            if (title.EndsWith(", The"))
            {
                title = "The " + title.Replace(", The", "");
            }
            try
            {
                WebClient c = new WebClient();
                var result = c.DownloadString($"http://www.omdbapi.com/?apikey=4e220919&t={title}");
                var imdbMovie = JsonConvert.DeserializeObject<ImdbMovie>(result);
                if (!string.IsNullOrWhiteSpace(imdbMovie.Poster))
                {
                    var ext = imdbMovie.Poster.Substring(imdbMovie.Poster.Length - 4);
                    c.DownloadFile(imdbMovie.Poster, $"{m.Id}{ext}");
                }                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{title}");
            }
            
        }
    }

    public class ImdbMovie
    {
        public string  Poster { get; set; }
    }
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RatingCount { get; set; }
        public decimal RatingAverage { get; set; }
    }
}
