using ChustaSoft.Common.Resources;
using System;
using System.Collections.Generic;

namespace ChustaSoft.Common.Exceptions
{
    public class ModelMappingException : Exception
    {

        public IList<string> PropertiesFailures { get; private set; }
        public Type OriginType { get; private set; }
        public Type TargetType { get; private set; }


        public ModelMappingException(Type originType, Type targetType)
              : base(string.Format(ExceptionResources.ElementNotFoundException_Type_ErrorMessage, originType.ToString(), targetType.ToString()))
        { }

        public ModelMappingException(Type originType, Type targetType, IList<string> propertiesFailures)
            : this(originType, targetType)
        { 
            PropertiesFailures = propertiesFailures;
        }


        public void AddFailure(string property)
        {
            PropertiesFailures.Add(property);
        }
    }
}
