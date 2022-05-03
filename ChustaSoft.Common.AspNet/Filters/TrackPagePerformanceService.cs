using ChustaSoft.Common.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ChustaSoft.Common.Filters
{

    public interface ITrackPagePerformanceService
    {
        void OnInit(PageHandlerExecutingContext context);
        void OnFinish(PageHandlerExecutedContext context);
    }



    public class TrackPagePerformanceService : ITrackPagePerformanceService
    {

        private readonly ILogger _logger;
        private Stopwatch _timer;


        public TrackPagePerformanceService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("TRACKING-PERFORMANCE");
        }

        public void OnInit(PageHandlerExecutingContext context)
        {
            _timer = Stopwatch.StartNew();
        }

        public void OnFinish(PageHandlerExecutedContext context)
        {
            _timer.Stop();
            if (context.Exception == null)
            {
                _logger.LogPerformance(context, _timer);
            }
        }
       
    }
}
