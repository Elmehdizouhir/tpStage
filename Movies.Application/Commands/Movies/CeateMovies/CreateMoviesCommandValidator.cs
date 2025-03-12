using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Movies.Domain.Entities;

namespace Movies.Application.Commands.Movies.CeateMovies
{
    public class CreateMoviesCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMoviesCommandValidator()
        {
            RuleFor(x => x.Category).NotEmpty()
            .WithMessage($"{nameof(Movie.Category)} cannot be empty")
            .MaximumLength(50)
            .WithMessage($"{nameof(Movie.Category)} cannot be longer than 50 characters");

            RuleFor(x => x.Title).NotEmpty()
            .WithMessage($"{nameof(Movie.Title)} cannot be empty")
            .MaximumLength(1000)
            .WithMessage($"{nameof(Movie.Title)} cannot be longer than 1000 characters");

            RuleFor(x => x.Description).NotEmpty()
            .WithMessage($"{nameof(Movie.Description)} cannot be empty")
            .MaximumLength(500)
            .WithMessage($"{nameof(Movie.Description)} cannot be longer than 500 characters");
        }
    }
    
}