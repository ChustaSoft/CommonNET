using ChustaSoft.Common.Enums;
using System;
using System.Reflection;


namespace ChustaSoft.Common.Exceptions
{

    /// <summary>
    /// Common Exception for Business validations
    /// </summary>
    public class BusinessException : Exception
    {

        #region Properties

        public ErrorType Type { get; private set; }
        public string Text { get; private set; }
        public FieldInfo Property { get; private set; }

        #endregion


        #region Constructors

        public BusinessException(string message) : base(message) { }

        public BusinessException(string message, Exception innerException) : base(message, innerException) { }

        public BusinessException(ErrorType type, string message, FieldInfo property) : base(message)
        {
            Type = type;
            Text = message;
            Property = property;
        }

        #endregion

    }
}
