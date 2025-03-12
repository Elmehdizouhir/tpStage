using MediatR;
using Movies.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Movies.Application.Commands.Movies.CreateMovies;
using Movies.Infrastructure;
namespace Movies.Application.Commands.Movies.DeleteMovies;
public class DeleteMoviesCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
{
    private readonly MoviesDbContext _moviesDbContext;
    public DeleteMoviesCommandHandler(MoviesDbContext moviesDbContext)
    {
        _moviesDbContext = moviesDbContext;
    }
    public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var moviesToDelete = await _moviesDbContext.Movies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (moviesToDelete == null)
        {
            throw new Exception("Movie not found");
        }
        _moviesDbContext.Movies.Remove(moviesToDelete);
        await _moviesDbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
