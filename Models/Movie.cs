namespace sMDB.Models
{
    // Model view of the Movie entries in the database
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }

    }
}
