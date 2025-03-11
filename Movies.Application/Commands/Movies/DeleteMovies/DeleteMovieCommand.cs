using System;
using MediatR;
namespace Movies.Application.Commands.Movies.DeleteMovies;
public record DeleteMoviesCommand(int Id) : IRequest<Unit>;
