using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Infrastructure
{
    public class MoviesDbContext : DbContext, IMoviesDbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) { }

        // Implémentation de la propriété Movies provenant de l'interface IMoviesDbContext
        public DbSet<Movie> Movies { get; set; }

        // Implémentation de la méthode SaveChangesAsync provenant de l'interface IMoviesDbContext
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
