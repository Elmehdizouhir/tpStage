using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Contracts.Errors
{
    public class ValidationError
    {
        public string Property { get; set; }
        public string ErrorMessage { get; set;}
    }
}