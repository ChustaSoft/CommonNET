using ChustaSoft.Common.Utilities;
using System.Collections.Generic;


namespace ChustaSoft.Common.Contracts
{
    public interface IBuilder<T> where T : class
    {

        ICollection<ErrorMessage> Errors { get; set; }

        T Build();

    }
}
