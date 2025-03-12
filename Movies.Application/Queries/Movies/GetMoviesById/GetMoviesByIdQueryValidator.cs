using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Movies.Domain.Entities;
namespace Movies.Application.Queries.Movies.GetMoviesById
{
    public class GetMoviesByIdQueryValidator : AbstractValidator<GetMoviesByIdQuery>
    {
        public GetMoviesByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
            .WithMessage($"{nameof(Movie.Id)} cannot be empty");

        }
    }
    
}