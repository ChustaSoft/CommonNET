using Microsoft.Extensions.Logging;

namespace ChustaSoft.Common.Wpf.Base
{
    public class TraceableViewModelBase<T> : ViewModelBase<T>
        where T : new()
    {

        protected readonly ILogger _logger;


        protected TraceableViewModelBase(ILogger logger)
            : base()
        {
            _logger = logger;
        }

    }
}
