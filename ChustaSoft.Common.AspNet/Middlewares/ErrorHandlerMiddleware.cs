using ChustaSoft.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ChustaSoft.Common.Middlewares
{

    /// <summary>
    /// Abstract definition for a centralized error handling middleware
    /// </summary>
    public abstract class ErrorHandlerMiddlewareBase
    {

        protected readonly RequestDelegate _next;
        protected readonly ILogger<ErrorHandlerMiddlewareBase> _logger;


        public ErrorHandlerMiddlewareBase(RequestDelegate next, ILogger<ErrorHandlerMiddlewareBase> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


        protected abstract Task HandleExceptionAsync(HttpContext context, Exception ex);

    }



    #region Default implementation

    /// <summary>
    /// Default implementationfor a centralized error handling middleware
    /// This one only manages general exceptions and custom Business exceptions
    /// </summary>
    public class DefaultErrorHandlerMiddleware : ErrorHandlerMiddlewareBase
    {

        public DefaultErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddlewareBase> logger)
            : base(next, logger)
        { }


        protected override Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var result = string.Empty;

            if (ex is BusinessException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                result = ex.Message;
                _logger.LogTrace($"[BusinessException]: {ex.Message}");
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                result = context.TraceIdentifier;
                _logger.LogError($"[{ex.GetType().Name}]-[{context.TraceIdentifier}]: {ex.Message}");
            }

            return context.Response.WriteAsync(result);
        }
    }

    #endregion

}
