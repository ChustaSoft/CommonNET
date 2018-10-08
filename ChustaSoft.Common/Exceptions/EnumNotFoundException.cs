using ChustaSoft.Common.Resources;
using System;


namespace ChustaSoft.Common.Exceptions
{
    public class EnumNotFoundException : Exception
    {

        public EnumNotFoundException(Type type, string str) 
            : base(string.Format(ExceptionResources.EnumNotFoundException_ErrorMessage, str, type.ToString())) { }

    }
}
