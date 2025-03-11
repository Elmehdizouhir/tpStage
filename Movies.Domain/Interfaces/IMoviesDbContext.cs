using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Infrastructure
{
    public interface IMoviesDbContext
    {
        DbSet<Movie> Movies { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
