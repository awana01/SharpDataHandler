using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHandler.RestTest.ObjectClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace DataHandler.RestTest
{


    class RestTest2
    {
        public String Uri = "https://app.asana.com";

        public String _requestUserWorkSpaceInfoEndPoint = "/api/1.0/users/me";

        public DateTime startTime, endTime;

        public int elapsedMillisecs;

        public string _workspaceID;

        [Test]
        [Description("awana.uhg@gmail.com: Details of User Workspaces")]
        public void Test_Json_Deserilization_01()
        {

            startTime = new DateTime();
            var _client = new RestClient(Uri);
            var _restRquest = new RestRequest(_requestUserWorkSpaceInfoEndPoint, Method.GET);
            _restRquest.AddHeader("authorization", "Bearer 0/38d75b5504a78662a2adb04410b9b366");
            //_restRquest.AddHeader("authorization", "Bearer 0/38d75b5504a78662a2adb04410b9b366");
            _restRquest.RequestFormat = DataFormat.Json;

            IRestResponse response = _client.Execute(_restRquest);
            var content = response.Content;
            var statusCode = response.StatusCode;

            Console.WriteLine("Headers: " + response.Headers.Count);
            Console.WriteLine("Status code: " + statusCode);
            Console.WriteLine("Content: " + content);

            var AsanaInfo = JsonConvert.DeserializeObject<AsanaUserProject>(content);
            Console.WriteLine(AsanaInfo.Data.Email);
            _workspaceID = AsanaInfo.Data.Workspaces[0].Gid;
            //var _workSpaceName = AsanaInfo.Data.Workspaces[0].Name;

            for (int i = 0; i < AsanaInfo.Data.Workspaces.Length; i++)
                Console.WriteLine("No: {0} WorkSpaceID: {1} WorkSpace Name: {2}", i, AsanaInfo.Data.Workspaces[i].Gid, AsanaInfo.Data.Workspaces[i].Name);

            Console.WriteLine(elapsedMillisecs);
        }

        [Test]
        [Description("awana.uhg@gmail.com: Details of User specific Workspace")]
        public void TestWorkSpaceInfo_02()
        {
            string _workSpaceSpecific = String.Format("/api/1.0/workspaces/{0}/users", _workspaceID);
            var _client = new RestClient(Uri);
            var _restRquest = new RestRequest(_workSpaceSpecific, Method.GET);
            _restRquest.AddHeader("authorization", "Bearer 0/38d75b5504a78662a2adb04410b9b366");
            //_restRquest.AddHeader("authorization", "Bearer 0/38d75b5504a78662a2adb04410b9b366");
            _restRquest.RequestFormat = DataFormat.Json;

            IRestResponse response = _client.Execute(_restRquest);
            var content = response.Content;
            var statusCode = response.StatusCode;

            Console.WriteLine("Headers: " + response.Headers.Count);
            Console.WriteLine("Status code: " + statusCode);
            Console.WriteLine("=====");
            Console.WriteLine("Content: " + content);
            Console.WriteLine("=====");

            var ProjectsInfo = JsonConvert.DeserializeObject<SpecificWorkSpaceInfo>(content);
            Console.WriteLine(ProjectsInfo.WorkSpaceInfo[0].Name);
        }

        [Test]
        [Description("awana.uhg@gmail.com: Get a project in specific workspace")]
        public void TestGetSpecificProjectInWorkSpace_03()
        {
            var _projectBlue = "709389129771629";
            string _projects = String.Format("/api/1.0/workspaces/{0}/projects", _projectBlue);
            var _client = new RestClient(Uri);
            var _restRquest = new RestRequest(_projects, Method.GET);
            _restRquest.AddHeader("authorization", "Bearer 0/38d75b5504a78662a2adb04410b9b366");
            _restRquest.RequestFormat = DataFormat.Json;

            IRestResponse response = _client.Execute(_restRquest);
            var content = response.Content;
            var statusCode = response.StatusCode;

            Console.WriteLine("Headers: " + response.Headers.Count);
            Console.WriteLine("Status code: " + statusCode);
            Console.WriteLine("=====");
            Console.WriteLine("Content: " + content);
            Console.WriteLine("=====");
        }

        [Test]
        [Description("awana.uhg@gmail.com: Create a project in specific workspace")]
        public void TestCreateSpecificProjectInWorkSpace_04()
        {
            var _projectBlue = "709389129771629";
            string _projects = String.Format("/workspaces/{0}/projects", _projectBlue);
            //var payload = "{\"data\":{\"name\":\"Json_project\"}}";
            var json = new JObject(new JProperty("data", new JObject(new JProperty("name", "project_1"))));



            var _client = new RestClient(Uri);
            var _restRequest = new RestRequest(_projects, Method.POST);

            _restRequest.AddHeader("authorization", "Bearer 0/38d75b5504a78662a2adb04410b9b366");
            _restRequest.AddHeader("Accept", "Application/Json");
            _restRequest.AddHeader("Content-Type", "application/json");

            //_restRequest.AddParameter("Application/Json", payload, ParameterType.RequestBody);
            //_restRequest.AddParameter("name", "Project_0012");
            //_restRequest.AddParameter("application/json", , ParameterType.RequestBody);

            _restRequest.RequestFormat = DataFormat.Json;
           _restRequest.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = _client.Execute(_restRequest);
            var content = response.Content;
            var statusCode = response.StatusCode;

            Console.WriteLine("Headers: " + response.Headers.Count);
            Console.WriteLine("Status code: " + statusCode);
            Console.WriteLine("=====");
            Console.WriteLine("Content: " + content);
            Console.WriteLine("=====");
        }





        //
    }
}
/*
 {
"data": {
"name": "Stuff to buy",
"archived": false,
"color": "light-green",
"current_status": {
"title": "Status Update - Jun 15",
"text": "The project is moving forward according to plan...",
"html_text": "<body>The project <strong>is</strong> moving forward according to plan...</body>",
"color": "green",
"created_by": {
"name": "Greg Sanchez"
}
},
/*
 * 'Content-Type: application/json' \
-H 'Accept: application/json' \
-H 'Authorization: Bearer {access-token}'
*/ 



