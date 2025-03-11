using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Movies.Infrastructure;


namespace Movies.Infrastructure
{
    public class MoviesDbContext : DbContext, IMoviesDbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        // Correction : Ajout de "override" pour éviter le warning CS0114
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
