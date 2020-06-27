using AdvertApi.DTOs.Requests;
using AdvertApi.Exceptions;
using AdvertApi.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdvertApi.Services
{
    public class EfSqlAdvertApiService : IDbAdvertApiService
    {


        private readonly AdvertApiContext _context;

        public EfSqlAdvertApiService(AdvertApiContext context)
        {
            _context = context;
        }




        public Client RegisterClient(RegisterClientRequest request)
        {


            var isClientInDatabase = _context.Clients.Where
                (m => m.FirstName == request.FirstName && m.LastName == request.LastName && m.Phone == request.Phone && m.Email == request.Email).FirstOrDefault();

            if(isClientInDatabase != null)
            {
                throw new ClientIsAlreadyInDatabase("Client is already in databse");
            }

            var isLoginInUse = _context.Clients.Count(m => m.Login == request.Login);

            if(isLoginInUse !=0)
            {
                throw new UserWithThisLoginAlreadyExists("Login is already use by another user, please change login name");
            }

            string salt = CreateSalt();
            string hashPassword = Create(request.Password, salt);

            var client = new Client 
            {

                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Login = request.Login,
                Password =hashPassword,
                Salt = salt

            };

            _context.Attach(client);
            _context.Add(client);
            _context.SaveChangesAsync();


            return client;

        }




        public static string Create(string value, string salt)
        {
            var valuesBytes = KeyDerivation.Pbkdf2(
                password: value,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
                );
            return Convert.ToBase64String(valuesBytes);
        }

        public static bool Validate(string value, string salt, string hash)
            => Create(value, salt) == hash;

        public static string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }

        }

       
    }
}
