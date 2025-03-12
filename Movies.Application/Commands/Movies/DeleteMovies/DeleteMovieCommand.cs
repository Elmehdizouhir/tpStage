using System;
using MediatR;

public record DeleteMovieCommand(int Id) : IRequest<Unit>;
