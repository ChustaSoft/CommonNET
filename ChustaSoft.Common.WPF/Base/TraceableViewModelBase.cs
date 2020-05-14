using Microsoft.Extensions.Logging;

namespace ChustaSoft.Common.Base
{
    /// <summary>
    /// ViewModel requiring ILogger implementation injected than can be used in the inherited models
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
