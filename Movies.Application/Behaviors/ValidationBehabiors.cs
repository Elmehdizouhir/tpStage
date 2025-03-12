using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Movies.Contracts.Errors;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using Movies.Contracts.Exceptions;

namespace Movies.Application.Behaviors
{
    public class ValidationBehabiors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehabiors(IEnumerable<IValidator<TRequest>> validators )
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)

        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(x => x.ValidateAsync(context, cancellationToken
                )));
            var failtures = validationResults.Where(f => ! f.IsValid)
            .SelectMany(f => f.Errors)
            .Select(f => new ValidationError
            {
                Property = f.PropertyName,
                ErrorMessage = f.ErrorMessage
            }).ToList();
            
            if (failtures.Any())
            {
                throw new CustomValidationException(failtures);
            }
            var response =  await next();
            return response;
        }
    }
}