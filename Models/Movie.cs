using System.ComponentModel.DataAnnotations.Schema;

namespace SMDb.Models
{
    // Model view of the Movie entries in the database
    public class Movie
    {
        public int MovieId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        public string? ImageUrl { get; set; }
        public string? TrailerUrl { get; set; }


    }
}
