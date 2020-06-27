using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AdvertApi.Exceptions
{
    public class BuildingAreNotOnTheSameStreet : Exception
    {
        public BuildingAreNotOnTheSameStreet()
        {
        }

        public BuildingAreNotOnTheSameStreet(string message) : base(message)
        {
        }

        public BuildingAreNotOnTheSameStreet(string message, Exception innerException) : base(message, innerException)
        {
        }

       
    }
}
