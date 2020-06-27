using AdvertApi.DTOs.Requests;
using AdvertApi.Exceptions;
using AdvertApi.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AdvertApi.Services
{
    public class EfSqlAdvertApiService : IDbAdvertApiService
    {


        private readonly AdvertApiContext _context;
        private readonly IConfiguration Configuration;
        public EfSqlAdvertApiService(AdvertApiContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }




        public Client RegisterClient(RegisterClientRequest request)
        {


            var isClientInDatabase = _context.Clients.Where
                (m => m.FirstName == request.FirstName && m.LastName == request.LastName && m.Phone == request.Phone && m.Email == request.Email).FirstOrDefault();

            if(isClientInDatabase != null)
            {
                throw new ClientIsAlreadyInDatabaseException("Client is already in databse");
            }

            var isLoginInUse = _context.Clients.Count(m => m.Login == request.Login);

            if(isLoginInUse !=0)
            {
                throw new UserWithThisLoginAlreadyExistsException("Login is already use by another user, please change login name");
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


        public string Login(LoginRequest request)
        {

            var userInfo = _context.Clients.Where(m => m.Login == request.Login).FirstOrDefault();

            if(userInfo == null)
            {
                throw new LoginIsIncorrectException("Login is incorrect");
            }

          

            if (!Validate(request.Password, userInfo.Salt, userInfo.Password))
            {
                throw new PasswordIsIncorrectException("Password is incorrect");
            }


            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userInfo.IdClient.ToString()),
                new Claim(ClaimTypes.Name, userInfo.Login)

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: "https://localhost:44376/api/client",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: creds
                );



            var refreshToken = Guid.NewGuid();


            userInfo.RefreshToken = refreshToken.ToString();
           // var client = new Client { 
           //     RefreshToken = refreshToken.ToString()
           // };
           //  _context.Attach(client);
           // _context.Entry(client).Property("RefreshToken").IsModified = true;
            _context.SaveChangesAsync();


            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);


            return $"\"accesToken\": \"{accessToken}\",\n\"refreshToken\": \"{refreshToken}\"" ;

        }


        public string RefreshToken(string refreshToken)
        {

            var userInfo = _context.Clients.Where(m => m.RefreshToken == refreshToken).FirstOrDefault();

            if(userInfo == null)
            {
                throw new WrongRefreshTokenException("Wrong refresh token");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userInfo.IdClient.ToString()),
                new Claim(ClaimTypes.Name, userInfo.Login)

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: "https://localhost:44376/api/client",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: creds
                );

            var refToken = Guid.NewGuid();


            userInfo.RefreshToken = refToken.ToString();
            //var client = new Client
            //{
            //    RefreshToken = refToken.ToString()
            //};
            //_context.Attach(client);
            //_context.Entry(client).Property("RefreshToken").IsModified = true;

            _context.SaveChangesAsync();

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);


            return $"\"accesToken\": \"{accessToken}\",\n\"refreshToken\": \"{refToken}\"";

        }

        public IEnumerable<Campaign> ListOfCampaigns()
        {
            var campaign = _context.Campaigns.OrderByDescending(m=>m.StartDate).Include(m => m.Client).Include(m => m.Banners).ToList();

            return campaign;
        }

        public Campaign CreateNewCampaign(CreateNewCampaignRequest request)
        {

            var clientInfo = _context.Clients.Where(m => m.IdClient == request.IdClient).FirstOrDefault();

            if(clientInfo == null)
            {
                throw new ClientNotExistsException($"Client with id={request.IdClient} not exists");
            }

            var fromBuildingStreet = _context.Buildings.Where(m => m.IdBuilding == request.FromIdBuilding).FirstOrDefault();
            var toBuildingStreet = _context.Buildings.Where(m => m.IdBuilding == request.ToIdBuilding).FirstOrDefault();

            if (!((toBuildingStreet.Street).Equals(fromBuildingStreet.Street)))
            {
                throw new BuildingAreNotOnTheSameStreet($"Buildings aren't on the same street, addresses you gave: {request.FromIdBuilding} and {request.ToIdBuilding}");
            }


            var campaing = new Campaign {


                IdClient = request.IdClient,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                PricePerSquareMeter = request.PricePerSquareMeter,
                FromIdBuilding = request.FromIdBuilding,
                ToIdBuilding = request.ToIdBuilding
            };



            _context.Attach(campaing);
            _context.Add(campaing);
            _context.SaveChanges();


            return campaing;


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
