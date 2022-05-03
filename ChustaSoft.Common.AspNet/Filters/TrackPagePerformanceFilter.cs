using Microsoft.AspNetCore.Mvc.Filters;

namespace ChustaSoft.Common.Filters
{
    public class TrackPagePerformanceFilter : IPageFilter
    {
        
        private readonly ITrackPagePerformanceService _trackPagePerformanceService;


        public TrackPagePerformanceFilter(ITrackPagePerformanceService trackPagePerformanceService)
        {
            _trackPagePerformanceService = trackPagePerformanceService;
        }


        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
            => _trackPagePerformanceService.OnInit(context);        

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
            => _trackPagePerformanceService.OnFinish(context);        

        public void OnPageHandlerSelected(PageHandlerSelectedContext context) { }

    }
}
