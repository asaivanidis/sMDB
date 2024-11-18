namespace SMDb.Models
{
    // Model view of the Movie entries in the database
    public class Movie
    {
        public int MovieId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string? TrailerUrl { get; set; }
        public string? CoverImageUrl { get; set; } // Cover image
        public List<string> ImageUrls { get; set; } = new List<string>(); // Additional images


    }
}
