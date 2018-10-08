using ChustaSoft.Common.Enums;
using System;
using System.Reflection;


namespace ChustaSoft.Common.Exceptions
{

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

        #endregion

    }
}
