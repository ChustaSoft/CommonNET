using ChustaSoft.Common.Utilities;
using System;
using System.Collections.Generic;

namespace ChustaSoft.Common.Contracts
{
    public interface IBuilder<T> where T : class
    {
        T Build();

    }
}
