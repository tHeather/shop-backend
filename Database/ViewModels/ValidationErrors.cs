using System;
using System.Collections.Generic;

namespace ShopBackend.BusinessLogic.ViewModels
{
    public class ValidationErrors
    {
        public ValidationErrors(IEnumerable<string> errors)
        {
            StatusCode = 400;
            Title = "Bad Request";
            Errors = errors;
        }

        public ValidationErrors(string error)
        {
            StatusCode = 400;
            Title = "Bad Request";
            Errors = new string[] { error };
        }

        public ValidationErrors(int statusCode, IEnumerable<string> errors)
        {
            StatusCode = statusCode;
            Errors = errors;

            Title = statusCode switch
            {            
                400  => "Bad Reques",
                401 => "Unauthorized",
                409 => "Conflict",
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(statusCode)),
            };
        }

        public int StatusCode { get; }
        public string Title { get; }
        public IEnumerable<string> Errors { get; }
    }
}