using ChustaSoft.Common.Constants;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace ChustaSoft.Common.Utilities
{

    /// <summary>
    /// Serialized extension for List<typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">Type object inside collection</typeparam>
    [CollectionDataContract(Name = SerializedNames.SerializableCollection)]
    public class SerializableCollection<T> : List<T> { }

}
