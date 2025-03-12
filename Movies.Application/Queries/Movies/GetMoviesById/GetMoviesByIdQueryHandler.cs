using MediatR;
using Movies.Application.Queries.Movies.GetMoviesById; //GetMoviesByIdQuery و GetMoviesByIdResponse
using Movies.Contracts.Responses; // GetMoviesResponse
using Microsoft.EntityFrameworkCore;  
using Mapster;
using Movies.Infrastructure;

namespace Movies.Appliction.Queries.Movies.GetMoviesById;
public class GetMoviesByIdQueryHandler : IRequestHandler<GetMoviesByIdQuery , GetMoviesByIdResponse>
{
    private readonly MoviesDbContext _moviesDbContext;
    public GetMoviesByIdQueryHandler(MoviesDbContext moviesDbContext)
    {
        _moviesDbContext = moviesDbContext;
    }
    public async Task<GetMoviesByIdResponse> Handle(GetMoviesByIdQuery request, CancellationToken cancellation)
    {
        var movie = await _moviesDbContext.Movies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellation);
        if (movie == null)
        {
            throw new Exception();
        }
        return movie.Adapt<GetMoviesByIdResponse>();
    }
}