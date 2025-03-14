using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Movies.Infrastructure;
using Movies.Contracts.Exceptions;
using Movies.Domain.Entities;
namespace Movies.Application.Commands.Movies.UpdateMovies
{
    public class UpdateMovieCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public required string  Title { get; set; } 
        public required string Description { get; set; } 
        public required string Category { get; set; } 
    }

    public class UpdateMoviesCommandHandler : IRequestHandler<UpdateMovieCommand, Unit>
    {
        private readonly MoviesDbContext _moviesDbContext;

        public UpdateMoviesCommandHandler(MoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var moviesToUpdate = await _moviesDbContext.Movies
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (moviesToUpdate is not null)
            {
                throw new NotFoundException($"{nameof(Movie)} with id {nameof(Movie.Id)} : {request.Id} was not found in database");
            }

            moviesToUpdate.Title = request.Title;
            moviesToUpdate.Description = request.Description;
            moviesToUpdate.Category = request.Category;

            _moviesDbContext.Movies.Update(moviesToUpdate);
            await _moviesDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
