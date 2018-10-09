using ChustaSoft.Common.Enums;
using ChustaSoft.Common.Exceptions;
using System.Runtime.Serialization;


namespace ChustaSoft.Common.Utilities
{

    [DataContract]
    public class ErrorMessage
    {
        
        #region Properties

        [DataMember]
        public ErrorType Type { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public string Property { get; set; }

        #endregion


        #region Constructor

        public ErrorMessage(ErrorType errorType, string errorText)
        {
            Type = errorType;
            Text = errorText;
        }
        
        public ErrorMessage(BusinessException exception)
        {
            Text = exception.Message;
            Type = exception.Type;
            Property = exception.Property?.Name ?? string.Empty;
        }

        #endregion

    }

}
