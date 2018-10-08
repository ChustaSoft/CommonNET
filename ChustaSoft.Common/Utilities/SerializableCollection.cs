using ChustaSoft.Common.Constants;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace ChustaSoft.Common.Utilities
{

    [CollectionDataContract(Name = SerializedNames.SerializableCollection)]
    public class SerializableCollection<T> : List<T> { }

}
