namespace MovieLensRecommender.Models
{
    public class Rating
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public int RatingValue { get; set; }
        public string Timestamp { get; set; }
    }

    public class RatingDto
    {
        public int MovieId { get; set; }
        public int? Rating { get; set; }
        public string Title { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public int RatingCount { get; set; }
    }
}