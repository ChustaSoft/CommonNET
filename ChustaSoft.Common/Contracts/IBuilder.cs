using ChustaSoft.Common.Utilities;
using System;
using System.Collections.Generic;

namespace ChustaSoft.Common.Contracts
{
    public interface IBuilder<T> where T : class
    {
        T Build();

        [Obsolete("This implementation will be removed in version 2.0. Use ITrackableBuilder instead for errors tracking")]
        ICollection<ErrorMessage> Errors { get; set;  }

    }
}
