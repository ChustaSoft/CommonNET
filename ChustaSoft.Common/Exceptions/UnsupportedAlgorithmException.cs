using ChustaSoft.Common.Resources;
using System;
using System.Security.Authentication;

namespace ChustaSoft.Common.Exceptions
{
    public class UnsupportedAlgorithmException : Exception
    {

        public UnsupportedAlgorithmException(HashAlgorithmType type)
            : base(string.Format(ExceptionResources.UnsupportedAlgorithmException_ErrorMessage, type.ToString()))
        { }

    }
}
