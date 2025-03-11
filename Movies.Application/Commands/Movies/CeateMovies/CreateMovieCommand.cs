using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;


public record CreateMoviesCommand(string Title, string Description, string Category) : IRequest<int>;
    