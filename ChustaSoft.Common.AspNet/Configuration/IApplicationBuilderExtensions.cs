using ChustaSoft.Common.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace ChustaSoft.Common.Configuration
{
    public static class IApplicationBuilderExtensions
    {

        public static void UseHttpContextLoggingMiddleware(this IApplicationBuilder applicationBuilder) 
        {
            applicationBuilder.UseMiddleware<HttpContextLoggingMiddleware>();
        }

        public static void UseErrorHandlingMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseErrorHandlingMiddleware<DefaultErrorHandlerMiddleware>();
        }

        public static void UseErrorHandlingMiddleware<THandler>(this IApplicationBuilder applicationBuilder)
            where THandler : ErrorHandlerMiddlewareBase
        {
            applicationBuilder.UseMiddleware<THandler>();
        }

    }
}
