using AdvertApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using AdvertApi.Services;
using AdvertApi.DTOs.Requests;
using AdvertApi.Models;
using Microsoft.AspNetCore.JsonPatch.Internal;
using System;
using System.Linq;

namespace AdvertApi.Controllers.Tests
{
    [TestClass()]
    public class ClientControllerTests
    {


        [TestMethod()]
        public void ListOfCampaignTest()
        {
            //Arrange
            var dbLayer = new Mock<IDbAdvertApiService>();
            dbLayer.Setup(d => d.ListOfCampaigns()).Returns(new List<Campaign>()
            {
                new Campaign{IdCampaign =1, IdClient=1, StartDate =DateTime.Parse("03-04-2020"), EndDate = DateTime.Parse("03-07-2020"), PricePerSquareMeter = 35, FromIdBuilding = 1, ToIdBuilding = 1 },
                new Campaign{IdCampaign =2, IdClient=2, StartDate =DateTime.Parse("01-02-2020"), EndDate = DateTime.Parse("01-03-2020"), PricePerSquareMeter = 40, FromIdBuilding = 2, ToIdBuilding = 2 },

            });

            var cont = new ClientController(dbLayer.Object);

            //Act
            var result = cont.ListOfCampaign();

            //Assert
            Assert.IsNotNull(result);


        }

        [TestMethod()]
        public void RegisterClientTest()
        {
            //Arrange
            var dbLayer = new Mock<IDbAdvertApiService>();
            var newRegisterClientRequest = new RegisterClientRequest
            {
                FirstName = "Tomek",
                LastName = "Palczewski",
                Email = "jakisTam@wp.pl",
                Phone ="666999666",
                Login = "abc",
                Password ="abcd"

            };

            var newClient = new Client
            {
                FirstName = "Tomek",
                LastName = "Palczewski",
                Email = "jakisTam@wp.pl",
                Phone = "666999666",
                Login = "abc",
                Password = "abcd"

            };


            dbLayer.Setup(m => m.RegisterClient(newRegisterClientRequest)).Returns(newClient);

            var cont = new ClientController(dbLayer.Object);

            //Act
            var result = cont.RegisterClient(newRegisterClientRequest);

            //Assert
            Assert.IsNotNull(result);
            

        }
    }
}