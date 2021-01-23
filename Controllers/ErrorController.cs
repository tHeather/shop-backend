using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StudyOnlineServer.Controllers
{
    [Route("api/error")]
    [ApiController]
    [AllowAnonymous]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Action that will be invoked for any call to this Controller in order to handle the current error
        /// </summary>
        /// <returns>A generic error formatted as JSON because we are in a REST API app context</returns>
        [HttpGet]
        //[HttpPost]
        //[HttpHead]
        //[HttpDelete]
        //[HttpPut]
        //[HttpOptions]
        //[HttpPatch]
        public JsonResult Handle()
        {
            //Get the exception that has implied the call to this controller
            Exception exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            //Log the exception via the content of the variable named "exception" if it is not NULL
            if (exception != null)
            {
                var innerExceptionMessage = GetInnerMostExceptionMessage(exception);
                var logLevel = DeterminateLogLevel(exception);
                _logger.Log(logLevel, exception, "Unexpected exception caught! " + innerExceptionMessage + " --- {TraceIdentifier}.", HttpContext.TraceIdentifier);
            }
            //We build a generic response with a JSON format because we are in a REST API app context
            //We also add an HTTP response header to indicate to the client app that the response 
            //is an error
            var responseBody = "Wystąpił błąd, spróbuj ponownie.";
            JsonResult response = new JsonResult(responseBody) { StatusCode = (int)HttpStatusCode.InternalServerError };
            Request.HttpContext.Response.Headers.Remove("X-ERROR");
            Request.HttpContext.Response.Headers.Add("X-ERROR", "true");
            return response;
        }

        private string GetInnerMostExceptionMessage(Exception exception)
        {
            if (exception.InnerException != null)
                return GetInnerMostExceptionMessage(exception.InnerException);

            return exception.Message;
        }

        private static LogLevel DeterminateLogLevel(Exception exception)
        {
            if (exception.Message.Contains("cannot open database", StringComparison.InvariantCultureIgnoreCase) ||
                exception.Message.Contains("a network-related", StringComparison.InvariantCultureIgnoreCase) ||
                exception.Message.Contains("bad authorization header format", StringComparison.CurrentCultureIgnoreCase) ||
                exception.Message.Contains("database error", StringComparison.CurrentCultureIgnoreCase))
                return LogLevel.Critical;

            return LogLevel.Error;
        }
    }
}
