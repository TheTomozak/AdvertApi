using AdvertApi.DTOs.Requests;
using AdvertApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertApi.Services
{
    public interface IDbAdvertApiService
    {

        public Client RegisterClient(RegisterClientRequest request);

    }
}
