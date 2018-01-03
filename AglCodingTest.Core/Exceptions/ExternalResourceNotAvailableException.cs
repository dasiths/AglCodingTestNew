using System;

namespace AglCodingTest.Core.Exceptions
{
    public class ExternalResourceNotAvailableException: Exception
    {
        public ExternalResourceNotAvailableException(string url, string msg = "")
            : base($"External resource {url} was not available. Message: {msg}")
        {
            
        }
    }
}
