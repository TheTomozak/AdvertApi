using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AdvertApi.Exceptions
{
    public class ClientNotExistsException : Exception
    {
        public ClientNotExistsException()
        {
        }

        public ClientNotExistsException(string message) : base(message)
        {
        }

        public ClientNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        
    }
}
