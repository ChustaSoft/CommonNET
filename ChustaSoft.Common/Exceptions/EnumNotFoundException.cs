using ChustaSoft.Common.Resources;
using System;


namespace ChustaSoft.Common.Exceptions
{

    /// <summary>
    /// Exception useful when an operation based on Enum types does not find the one specified
    /// </summary>
    public class EnumNotFoundException : Exception
    {

        public EnumNotFoundException(Type type, string str) 
            : base(string.Format(ExceptionResources.EnumNotFoundException_ErrorMessage, str, type.ToString())) { }

    }
}
