namespace ChustaSoft.Common.Contracts
{
    public interface IMapper<TSource, TTarget>
    {

        TTarget MapFromSource(TSource source);

        TSource MapToSource(TTarget target);

    }


    public interface IMapper<TSource1, TSource2, TTarget> : IMapper<TSource1, TTarget>
    {
        TTarget MapFromSource(TSource1 primarySource, TSource2 secondarySource);
    }


    public interface IMapper<TSource1, TSource2, TSource3, TTarget> : IMapper<TSource1, TSource2, TTarget>
    {
        TTarget MapFromSource(TSource1 primarySource, TSource2 secondarySource, TSource3 thridSource);
    }

}
