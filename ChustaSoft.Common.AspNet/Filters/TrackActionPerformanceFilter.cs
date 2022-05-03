using Microsoft.AspNetCore.Mvc.Filters;

namespace ChustaSoft.Common.Filters
{
    public class TrackActionPerformanceFilter : IActionFilter
    {
        
        private readonly ITrackActionPerformanceService _trackActionPerformanceService;


        public TrackActionPerformanceFilter(ITrackActionPerformanceService trackActionPerformanceService)
        {
            _trackActionPerformanceService = trackActionPerformanceService;
        }


        public void OnActionExecuting(ActionExecutingContext context)
            => _trackActionPerformanceService.OnInit(context);        

        public void OnActionExecuted(ActionExecutedContext context)
            => _trackActionPerformanceService.OnFinish(context);

    }
}
