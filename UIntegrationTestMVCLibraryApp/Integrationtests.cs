using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using MVCLibraryApp;
using MVCLibraryApp.Controllers;
using System.Net;

namespace UIntegrationTestMVCLibraryApp




{
    public class IntegrationTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            // Create a new HttpClient instance before each test
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5076"); // Adjust the base URL as needed
        }

        [Test]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("/"); // Specify the endpoint URL here

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.AreEqual("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());


        }

        [Test]
        public async Task TestDashboardGet()
        {
            // Act
            var response = await _client.GetAsync("/Bezoeker/Dashboard");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task TestRegisterGet()
        {
            // Act
            var response = await _client.GetAsync("/Bezoeker/Register");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


    }
}