using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataHandler.RestTest.ObjectClasses
{
    public class AsanaUserProject
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

    }

    public partial class Data
    {
        [JsonProperty("gid")]
        public string Gid { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photo")]
        public object Photo { get; set; }

        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }

        [JsonProperty("workspaces")]
        public Workspace[] Workspaces { get; set; }
    }

    public partial class Workspace
    {
        [JsonProperty("gid")]
        public string Gid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
    }

}


