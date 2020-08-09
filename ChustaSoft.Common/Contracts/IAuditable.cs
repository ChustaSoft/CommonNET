using System;

namespace ChustaSoft.Common.Contracts
{
    public interface IAuditable
    {
        DateTimeOffset CreationDate { get; set; }
        DateTimeOffset? LastModificationDate { get; set; }
    }
}
