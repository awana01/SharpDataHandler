using System;
using RestSharp;
using NUnit.Framework;

namespace DataHandler.RestTest
{
    
    [TestFixture]
    public class RestTest1
    {
        [Test]
        [Description("Get details of the aviliable users")]
        public void TestGetRequest()
        {
            var _client = new RestClient("https://reqres.in/");
            var _restRquest = new RestRequest("/api/users?page=2", Method.GET);
            _restRquest.AddHeader("Accept", "Applicatio/Json");
            _restRquest.RequestFormat = DataFormat.Json;

            IRestResponse response = _client.Execute(_restRquest);
            var content = response.Content;
            var statusCode = response.StatusCode;

            Console.WriteLine(content);
        }

        [Test]
        [Description("Login with valid credentials")]
        public void TestPost_LoginRequest()
        {

            var _client = new RestClient("https://reqres.in/");
            var _restRquest = new RestRequest("/api/login", Method.POST);
            _restRquest.AddHeader("Accept", "Applicatio/Json");
            _restRquest.AddParameter("email", "eve.holt@reqres.in");
            _restRquest.AddParameter("password", "cityslicka");

            _restRquest.RequestFormat = DataFormat.Json;

            IRestResponse response = _client.Execute(_restRquest);
            var content = response.Content;
            var statusCode = response.StatusCode;

            Console.WriteLine(content);
            Console.WriteLine(statusCode);

            //Assert.AreEqual("200", statusCode);
        }

        [Test]
        [Description("Login with invalid credentials")]
        public void TestPost_InvalidLoginRequest()
        {

            var _client = new RestClient("https://reqres.in/");
            var _restRquest = new RestRequest("/api/login", Method.POST);
            _restRquest.AddHeader("Accept", "Applicatio/Json");
            _restRquest.AddParameter("email", "eve.holt@reqres.in");
            _restRquest.AddParameter("password", "");

            _restRquest.RequestFormat = DataFormat.Json;

            IRestResponse response = _client.Execute(_restRquest);
            var content = response.Content;
            var statusCode = response.StatusCode;

            Console.WriteLine(content);
            Console.WriteLine(statusCode);
        }
    }
}
