using ChustaSoft.Common.Resources;
using System;

namespace ChustaSoft.Common.Exceptions
{

    /// <summary>
    /// Exception useful for cases in which a filtering does not find an entry for a specific field, or that the type itself has not been found
    /// </summary>
    public class ElementNotFoundException : Exception
    {

        public ElementNotFoundException(Type type)
            : base(string.Format(ExceptionResources.ElementNotFoundException_Type_ErrorMessage, type.ToString())) { }

        public ElementNotFoundException(Type type, string property)
            : base(string.Format(ExceptionResources.ElementNotFoundException_TypeAndError_ErrorMessage, type.ToString(), property)) { }

    }
}
