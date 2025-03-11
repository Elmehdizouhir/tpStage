using MediatR;
using Movies.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Movies.Application.Commands.Movies.CreateMovies;
public class DeleteMoviesCommandHandler : IRequestHandler<DeleteMoviesCommand, Unit>
{
    private readonly MoviesDbContext _moviesDbContext;
    public DeleteMoviesCommandHandler(MoviesDbContext moviesDbContext)
    {
        _moviesDbContext = moviesDbContext;
    }
    public async Task<unit> Handle(DeleteMoviesCommand request, CancellationToken cancellationToken)
    {
        var moviesToDelete = await _moviesDbContext.Movies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (moviesToDelete == null)
        {
            throw Exception();
        }
        _moviesDbContext.Movies.Remove(moviesToDelete);
        await _moviesDbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
