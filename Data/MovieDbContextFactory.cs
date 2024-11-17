using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace SMDb.Data
{
    public class MovieDbContextFactory : IDesignTimeDbContextFactory<MovieDbContext>
    {
        public MovieDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieDbContext>();
            optionsBuilder.UseNpgsql("Host=smdb-database;Database=smdb-database;Username=smdb;Password=lHckjHWUNGrKgPYJdw9z;");
            return new MovieDbContext(optionsBuilder.Options);
        }
    }
}