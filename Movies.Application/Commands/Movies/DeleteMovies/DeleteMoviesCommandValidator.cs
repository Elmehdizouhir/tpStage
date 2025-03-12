using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Movies.Domain.Entities;
namespace Movies.Application.Commands.Movies.DeleteMovies
{
    public class DeleteMoviesCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMoviesCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
            .WithMessage($"{nameof(Movie.Id)} cannot be empty");

        }
    }
    
}