namespace MovieLensRecommender.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? RatingCount { get; set; }
        public string CardImage { get; set; }
    }
}