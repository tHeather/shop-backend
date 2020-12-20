using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace shop_backend.ViewModels
{
    public class ValidationErrors
    {
        public ValidationErrors(IEnumerable<string> errors)
        {
            StatusCode = StatusCodes.Status400BadRequest;
            Title = "Bad Request";
            Errors = errors;
        }

        public ValidationErrors(string error)
        {
            StatusCode = StatusCodes.Status400BadRequest;
            Title = "Bad Request";
            Errors = new string[] { error };
        }

        public ValidationErrors(int statusCode, IEnumerable<string> errors)
        {
            StatusCode = statusCode;
            Errors = errors;

            Title = statusCode switch
            {            
                StatusCodes.Status400BadRequest  => "Bad Reques",
                StatusCodes.Status401Unauthorized => "Unauthorized",
                StatusCodes.Status409Conflict => "Conflict",
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(statusCode)),
            };
        }

        public int StatusCode { get; }
        public string Title { get; }
        public IEnumerable<string> Errors { get; }
    }
}