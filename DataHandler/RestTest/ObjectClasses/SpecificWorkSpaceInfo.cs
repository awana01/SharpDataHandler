using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataHandler.RestTest.ObjectClasses
{
    class SpecificWorkSpaceInfo
    {
        [JsonProperty("data")]
        public WorkSpaceData[] WorkSpaceInfo { get; set; }

       


    }
    public partial class WorkSpaceData
    {
        [JsonProperty("gid")]
        public string Gid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
    }








}
