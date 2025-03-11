using System;
using MediatR;
namespace Movies.Application.Commands.Movies.UpdateMovies;
public record UpdateMoviesCommand(int id,string Title, string Description, string Category ) : IRequest<Uint>;

