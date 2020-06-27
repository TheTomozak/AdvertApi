using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AdvertApi.Exceptions
{
    public class PasswordIsIncorrectException : Exception
    {
        public PasswordIsIncorrectException()
        {
        }

        public PasswordIsIncorrectException(string message) : base(message)
        {
        }

        public PasswordIsIncorrectException(string message, Exception innerException) : base(message, innerException)
        {
        }

       
    }
}
