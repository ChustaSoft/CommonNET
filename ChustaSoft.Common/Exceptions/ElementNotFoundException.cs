using ChustaSoft.Common.Resources;
using System;

namespace ChustaSoft.Common.Exceptions
{
    public class ElementNotFoundException : Exception
    {

        public ElementNotFoundException(Type type)
            : base(string.Format(ExceptionResources.ElementNotFoundException_Type_ErrorMessage, type.ToString())) { }

        public ElementNotFoundException(Type type, string property)
            : base(string.Format(ExceptionResources.ElementNotFoundException_TypeAndError_ErrorMessage, type.ToString(), property)) { }

    }
}
