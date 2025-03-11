using MediatR;

namespace Movies.Application.Queries.Movies.GetMoviesById 
{
    public record GetMoviesByIdQuery(int Id) : IRequest<GetMoviesByIdResponse>;
}
