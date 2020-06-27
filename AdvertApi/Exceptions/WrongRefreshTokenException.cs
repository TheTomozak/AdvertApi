using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AdvertApi.Exceptions
{
    public class WrongRefreshTokenException : Exception
    {
        public WrongRefreshTokenException()
        {
        }

        public WrongRefreshTokenException(string message) : base(message)
        {
        }

        public WrongRefreshTokenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        
    }
}
