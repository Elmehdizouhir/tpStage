using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;


public record CreateMovieCommand(string Title, string Description, string Category) : IRequest<int>;
    