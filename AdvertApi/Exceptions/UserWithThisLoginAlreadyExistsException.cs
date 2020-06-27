using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AdvertApi.Exceptions
{
    public class UserWithThisLoginAlreadyExistsException : Exception
    {
        public UserWithThisLoginAlreadyExistsException()
        {
        }

        public UserWithThisLoginAlreadyExistsException(string message) : base(message)
        {
        }

        public UserWithThisLoginAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        
    }
}
