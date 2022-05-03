using Microsoft.AspNetCore.Mvc.Filters;

namespace ChustaSoft.Common.Filters
{
    internal class TrackActionPerformanceAttribute : ActionFilterAttribute
    {
        
        private readonly ITrackActionPerformanceService _trackActionPerformanceService;


        public TrackActionPerformanceAttribute(ITrackActionPerformanceService trackActionPerformanceService)
        {
            _trackActionPerformanceService = trackActionPerformanceService;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
            => _trackActionPerformanceService.OnInit(context);

        public override void OnActionExecuted(ActionExecutedContext context)
            =>  _trackActionPerformanceService.OnFinish(context);

    }
}
