using System.Runtime.Serialization;


namespace ChustaSoft.Common.Enums
{

    [DataContract]
    public enum ActionResponseType
    {
        [EnumMember]
        Success,

        [EnumMember]
        Warning,

        [EnumMember]
        Error
    }
}
