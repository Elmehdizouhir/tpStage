using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Movies.Contracts.Exceptions;

namespace Movies.Presentation.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = CreateProblemDetails(exception);
            context.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }

        private static ProblemDetails CreateProblemDetails(Exception exception)
        {
            var problemDetails = exception switch
            {
                NotFoundException => new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Not Found",
                    Detail = exception.Message
                },
                CustomValidationException => new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Validation Error",
                    Detail = "One or more validation errors occurred"
                },
                _ => new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred"
                }
            };

            if (exception is CustomValidationException customValidationException)
            {
                problemDetails.Extensions["errors"] = customValidationException.ValidationErrors;
            }

            return problemDetails;
        }
    }
}
