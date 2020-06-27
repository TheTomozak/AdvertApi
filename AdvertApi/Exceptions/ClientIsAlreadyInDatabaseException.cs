using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AdvertApi.Exceptions
{
    public class ClientIsAlreadyInDatabaseException : Exception
    {
        public ClientIsAlreadyInDatabaseException()
        {
        }

        public ClientIsAlreadyInDatabaseException(string message) : base(message)
        {
        }

        public ClientIsAlreadyInDatabaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        
    }
}
