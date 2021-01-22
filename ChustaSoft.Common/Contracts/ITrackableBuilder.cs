using ChustaSoft.Common.Utilities;
using System.Collections.Generic;

namespace ChustaSoft.Common.Contracts
{
    public interface ITrackableBuilder<T> 
        : IBuilder<T> where T : class
    {

        //ICollection<ErrorMessage> Errors { get; } //TODO: Pending to uncomment in version 2.0 once the IBuilder property for Errors has been removed

    }
}
