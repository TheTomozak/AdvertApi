using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AdvertApi.Exceptions
{
    public class ClientIsAlreadyInDatabase : Exception
    {
        public ClientIsAlreadyInDatabase()
        {
        }

        public ClientIsAlreadyInDatabase(string message) : base(message)
        {
        }

        public ClientIsAlreadyInDatabase(string message, Exception innerException) : base(message, innerException)
        {
        }

        
    }
}
