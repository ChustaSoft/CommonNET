using System;

namespace ChustaSoft.Common.Contracts
{
    interface IAuditable
    {
        DateTimeOffset CreationDate { get; set; }
        DateTimeOffset LastModificationDate { get; set; }
    }
}
