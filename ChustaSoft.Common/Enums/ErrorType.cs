using System.Runtime.Serialization;

namespace ChustaSoft.Common.Enums
{
    [DataContract]
    public enum ErrorType
    {
        [EnumMember]
        Required,

        [EnumMember]
        Invalid,

        [EnumMember]
        Validation,

        [EnumMember]
        Unknown,
    }
}
