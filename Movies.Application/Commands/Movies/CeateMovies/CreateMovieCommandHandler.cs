using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Movies.Domain.Entities;

using Movies.Infrastructure;

namespace Movies.Application.Commands.Movies.CreateMovies;
 
public class CreateMoviesCommandHandler : IRequestHandler<CreateMovieCommand, int>
{
    private readonly MoviesDbContext _moviesDbContext;
    public CreateMoviesCommandHandler(MoviesDbContext moviesDbContext)
    {
        _moviesDbContext = moviesDbContext;
    }

    public MoviesDbContext MoviesDbContext => _moviesDbContext;

    public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = new Movie
        {
            Title = request.Title,
            Category = request.Category,
            Description = request.Description,
            CreateDate = DateTime.Now.ToUniversalTime()
        };
        await MoviesDbContext.AddAsync(movie, cancellationToken);
        await MoviesDbContext.SaveChangesAsync(cancellationToken);

        return movie.Id;
    }
}
