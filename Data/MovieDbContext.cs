using Microsoft.EntityFrameworkCore;
using SMDb.Models;

namespace SMDb.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

    }
}
