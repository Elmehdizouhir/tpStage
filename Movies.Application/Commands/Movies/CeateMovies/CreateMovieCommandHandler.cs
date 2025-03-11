using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;


using Movies.Infrastructure;

namespace Movies.Application.Commands.Movies.CreateMovies;
 
public class CreateMoviesCommandHandler : IRequestHandler<CreateMoviesCommand, int>
{
    private readonly MoviesDbContext _moviesDbContext;
    public CreateMoviesCommandHandler(MoviesDbContext moviesDbContext)
    {
        _moviesDbContext = moviesDbContext;
    }

    public MoviesDbContext MoviesDbContext => _moviesDbContext;

    public async Task<int> Handle(CreateMoviesCommand request, CancellationToken cancellationToken)
    {
        var movie = new Movies
        {
            Title = request.Title,
            Category = request.Category,
            Description = request.Description,
            DateTime = DateTime.Now.ToUniversalTime()
        };
        await MoviesDbContext.AddAsync(movie, cancellationToken);
        await MoviesDbContext.SaveChangesAsync(cancellationToken);

        return movie.Id;
    }
}
