using ChustaSoft.Common.Utilities;
using System.Collections.Generic;


namespace ChustaSoft.Common.Helpers
{
    public interface IBuilder<T> where T : class
    {

        ICollection<ErrorMessage> Errors { get; set; }

        T Build();

    }
}
