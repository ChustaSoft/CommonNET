namespace ChustaSoft.Common.Contracts
{
    public interface IKeyable<TKey>
    {
        TKey Id { get; set; }
    }
}
