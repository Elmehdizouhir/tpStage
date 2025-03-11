using MediatR;

namespace Movies.Application.Querties.Movies.GetMovies;
public record GetMoviesQuery () : IRequest<GetMoviesResponse>;

