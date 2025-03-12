using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Contracts.Errors;
namespace Movies.Contracts.Exceptions
{
    public class CustomValidationException : Exception
    {
        private List<ValidationError> _validationErrors;
        public CustomValidationException(List<ValidationError> validationErrors)
        {
            _validationErrors = validationErrors;
        }

        public List<ValidationError> ValidationErrors { get; set;}
    }
}