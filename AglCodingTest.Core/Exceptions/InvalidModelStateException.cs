using System;

namespace AglCodingTest.Core.Exceptions
{
    public class InvalidModelStateException: Exception
    {
        public InvalidModelStateException(string message): base(message)
        {
            
        }
    }
}
