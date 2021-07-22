namespace ChustaSoft.Common.Contracts
{
    public interface IBuilder<T> where T : class
    {
        T Build();

    }
}
