using ChustaSoft.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ChustaSoft.Common.Middlewares
{
    public class ErrorHandlerMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;


        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
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


        private Task HandleExceptionAsync(HttpContext context, Exception ex)
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
}
