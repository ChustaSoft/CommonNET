using ChustaSoft.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ChustaSoft.Common.Middlewares
{
    public class ErrorHandlerMiddleware
    {

        private readonly RequestDelegate _next;


        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
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
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                result = context.TraceIdentifier;
            }

            return context.Response.WriteAsync(result);
        }

    }
}
