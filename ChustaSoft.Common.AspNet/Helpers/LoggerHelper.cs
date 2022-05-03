using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace ChustaSoft.Common.Helpers
{
    public static class LoggerHelper
    {

        private static readonly Action<ILogger, string, string, long, Exception> _logPerformanceAction;


        static LoggerHelper()
        {
            _logPerformanceAction = LoggerMessage.Define<string, string, long>(LogLevel.Information, 0, "{Action}-{Method} took: {ElapsedMiliseconds}");
        }


        public static void LogPerformance(this ILogger logger, ActionExecutedContext actionContext, Stopwatch stopwatch)
        {            
            if (actionContext.Exception == null)
            {
                _logPerformanceAction(logger, actionContext.HttpContext.Request.Path, actionContext.HttpContext.Request.Method, stopwatch.ElapsedMilliseconds, null);
            }
        }

        public static void LogPerformance(this ILogger logger, PageHandlerExecutedContext pageContext, Stopwatch stopwatch)
        {
            if (pageContext.Exception == null)
            {
                _logPerformanceAction(logger, pageContext.HttpContext.Request.Path, pageContext.HttpContext.Request.Method, stopwatch.ElapsedMilliseconds, null);
            }
        }

    }
}
