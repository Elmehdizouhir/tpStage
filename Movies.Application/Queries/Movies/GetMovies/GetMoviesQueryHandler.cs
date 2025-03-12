using Movies.Application.Queries.Movies.GetMovies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Movies.Contracts.Responses;
using Movies.Infrastructure;
using Microsoft.EntityFrameworkCore;
namespace Movies.Application.Queries.Movies.GetMovies
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery , GetMoviesResponse>
    {
        private readonly MoviesDbContext _moviesDbContext;
        public GetMoviesQueryHandler(MoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }
        public async Task<GetMoviesResponse> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _moviesDbContext.Movies.ToListAsync(cancellationToken);
            return movies.Adapt<GetMoviesResponse>();
            
        }
    }
}