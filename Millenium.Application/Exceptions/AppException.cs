using System;

namespace Millenium.Application.Exceptions
{
    public abstract class AppException : Exception
    {
        protected AppException(string message) : base(message)
        {
            
        }
    }
}