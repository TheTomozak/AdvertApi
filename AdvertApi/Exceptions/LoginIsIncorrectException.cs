using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AdvertApi.Exceptions
{
    public class LoginIsIncorrectException : Exception
    {
        public LoginIsIncorrectException()
        {
        }

        public LoginIsIncorrectException(string message) : base(message)
        {
        }

        public LoginIsIncorrectException(string message, Exception innerException) : base(message, innerException)
        {
        }

      
    }
}
