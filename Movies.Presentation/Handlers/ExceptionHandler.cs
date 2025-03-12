using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.Contracts.Exceptions;
namespace Movies.Presentation.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        public  async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception , CancellationToken cancellationToken) 
        {

        }

        private static ProblemDetails CreateProblemDetails(Exception exception)
        {
            CreateProblemDetails problemDetails = exception switch
            {
                NotFoundException => CreateProblemDetails(StatusCodes.Status404NotFound, 
                "Not Found",exception.Message),
                CustomValidationException => CreateProblemDetails(StatusCodes.Status404NotFound,
                "Validation Error", "One or more validation errors occured"),
                _ => CreateProblemDetails(statusCodes.Status500InternalServerError,
                "Internal Server Error", "An unexpected error occured")
            };
            if (exception is CustomValidationException customValidationException)
            {
                problemDetails.Extensions["errors"] = customValidationException.ValidationErrors;
            }
            return problemDetails;
        }
        private static ProblemDetails CreateProblemDetails(int status , string title, string detail)
                {
                    return new problemDetails
                    {
                        Status = status,
                        Title = title,
                        problemDetails = datail
                    };
                }
    }
}