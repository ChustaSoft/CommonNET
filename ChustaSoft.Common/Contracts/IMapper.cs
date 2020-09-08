using System;

namespace ChustaSoft.Common.Contracts
{
    [Obsolete("This implementation will be removed in version 2.0")]
    public interface IMapper<TSource, TTarget>
    {

        TTarget MapFromSource(TSource source);

        TSource MapToSource(TTarget target);

    }

    [Obsolete("This implementation will be removed in version 2.0")]
    public interface IMapper<TSource1, TSource2, TTarget> : IMapper<TSource1, TTarget>
    {
        TTarget MapFromSource(TSource1 primarySource, TSource2 secondarySource);
    }

    [Obsolete("This implementation will be removed in version 2.0")]
    public interface IMapper<TSource1, TSource2, TSource3, TTarget> : IMapper<TSource1, TSource2, TTarget>
    {
        TTarget MapFromSource(TSource1 primarySource, TSource2 secondarySource, TSource3 thridSource);
    }

}
