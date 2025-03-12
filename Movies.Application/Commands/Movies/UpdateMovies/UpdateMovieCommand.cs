using System;
using MediatR;

public record UpdateMovieCommand(int Id,string Title, string Description, string Category ) : IRequest<Unit>;

