using MediatR;
using Movies.Contracts.Responses;
namespace Movies.Application.Queries.Movies.GetMoviesById 
{
    public record GetMoviesByIdQuery(int Id) : IRequest<GetMoviesByIdResponse>;
}
