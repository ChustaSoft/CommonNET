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


        #region Constructor

        public BusinessException(ErrorType type, string text, FieldInfo property) : base(text)
        {
            Type = type;
            Text = text;
            Property = property;
        }

        public BusinessException(string message, Exception innerException) : base(message, innerException) { }

        #endregion

    }
}
