using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AdvertApi.Exceptions
{
    public class UserWithThisLoginAlreadyExists : Exception
    {
        public UserWithThisLoginAlreadyExists()
        {
        }

        public UserWithThisLoginAlreadyExists(string message) : base(message)
        {
        }

        public UserWithThisLoginAlreadyExists(string message, Exception innerException) : base(message, innerException)
        {
        }

        
    }
}
