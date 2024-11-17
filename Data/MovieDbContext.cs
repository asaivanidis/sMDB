using Microsoft.EntityFrameworkCore;
using SMDb.Models;

namespace SMDb.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=smdb-database;Database=smdb-database;Username=smdb;Password=lHckjHWUNGrKgPYJdw9z;");
            }
        }
    }
}