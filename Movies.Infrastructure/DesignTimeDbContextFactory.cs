using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Movies.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MoviesDbContext>
    {
        public MoviesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MoviesDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-1RI9KUN;Database=MoviesDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new MoviesDbContext(optionsBuilder.Options);
        }
    }
}
