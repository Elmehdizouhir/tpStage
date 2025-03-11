using System;
using MediatR;
using Movies.Application.Interfaces; // تأكد من الاستيراد الصحيح
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Commands.Movies.UpdateMovies
{
    public class UpdateMoviesCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }

    public class UpdateMoviesCommandHandler : IRequestHandler<UpdateMoviesCommand, Unit>
    {
        private readonly MoviesDbContext _moviesDbContext;

        public UpdateMoviesCommandHandler(MoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }

        public async Task<Unit> Handle(UpdateMoviesCommand request, CancellationToken cancellationToken)
        {
            var moviesToUpdate = await _moviesDbContext.Movies
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (moviesToUpdate == null)
            {
                throw new Exception("Movie not found");
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
