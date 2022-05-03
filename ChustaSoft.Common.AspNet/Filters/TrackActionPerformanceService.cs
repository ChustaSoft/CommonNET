using ChustaSoft.Common.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ChustaSoft.Common.Filters
{

    public interface ITrackActionPerformanceService
    {
        void OnInit(ActionExecutingContext context);
        void OnFinish(ActionExecutedContext context);
    }



    public class TrackPerformanceService : ITrackActionPerformanceService
    {

        private readonly ILogger _logger;
        private Stopwatch _timer;


        public TrackPerformanceService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("TRACKING-PERFORMANCE");
        }

        public void OnInit(ActionExecutingContext context)
        {
            _timer = Stopwatch.StartNew();
        }

        public void OnFinish(ActionExecutedContext context)
        {
            _timer.Stop();
            if (context.Exception == null)
            {
                _logger.LogPerformance(context, _timer);
            }
        }
       
    }
}
