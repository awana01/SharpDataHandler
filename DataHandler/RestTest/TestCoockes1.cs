using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;

namespace DataHandler.RestTest
{
    [TestFixture]
    class TestCoockes1
    {
        public String Uri = "https://app.asana.com";
        public String _requestEndPoint = "/api/1.0/users/me";

       [Test]
       [Description("zen.moser1985@gmail.com")]
       public void Test01()
       {
            var _client = new RestClient(Uri);
            var _restRquest = new RestRequest(_requestEndPoint, Method.GET);
            _restRquest.AddHeader("authorization", "Bearer 1/1167265732153354:8d8c241041855c821deec52c7481fc00");
            //_restRquest.AddHeader("authorization", "Bearer 0/38d75b5504a78662a2adb04410b9b366");
            _restRquest.RequestFormat = DataFormat.Json;

            IRestResponse response = _client.Execute(_restRquest);
            var content = response.Content;
            var statusCode = response.StatusCode;

            Console.WriteLine("Headers: " + response.Headers.Count);
            foreach(var head in response.Headers)
            {
                Console.WriteLine("Header :" + head);
            }

            Console.WriteLine("X-XSS-Protection: {0}", response.Headers[4]);
            Console.WriteLine("Status code: "+statusCode);
            Console.WriteLine("Content: "+content);
       }

        [Test]
        [Description("zen.moser1985@gmail.com")]
        public void Test02()
        {
            var _client = new RestClient(Uri);
            var _restRquest = new RestRequest(_requestEndPoint, Method.GET);
            _restRquest.AddHeader("authorization", "Bearer 1/1167265732153354:8d8c241041855c821deec52c7481fc00");
            //_restRquest.AddHeader("authorization", "Bearer 0/38d75b5504a78662a2adb04410b9b366");
            _restRquest.RequestFormat = DataFormat.Json;

            IRestResponse response = _client.Execute(_restRquest);
            var content = response.Content;
            var statusCode = response.StatusCode;

            Console.WriteLine("Cookies: " + response.Cookies.Count);
            foreach(var cookie in response.Cookies)
            {
                Console.WriteLine("Cookie: {0}", cookie);
            }
        }


        [Test]
        [Description("awana.uhg@gmail.com")]
        public void Test03()
        {
            var _client = new RestClient(Uri);
            var _restRquest = new RestRequest(_requestEndPoint, Method.GET);
            _restRquest.AddHeader("authorization", "Bearer 0/38d75b5504a78662a2adb04410b9b366");
            _restRquest.RequestFormat = DataFormat.Json;

            IRestResponse response = _client.Execute(_restRquest);
            var content = response.Content;
            var statusCode = response.StatusCode;

            Console.WriteLine(statusCode);
            Console.WriteLine(content);
        }








    }
}
