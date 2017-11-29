using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Samples.Kinect.BodyBasics.Json
{
    public class JsonProperties
    {
        public string ORG_ID { get; set; } = string.Empty;
        public string DEVICE_ID { get; set; } = string.Empty;
        public string DEVICE_TYPE { get; set; } = string.Empty;
        public string TOKEN_KEY { get; set; } = string.Empty;
        public string AUTH_TOKEN { get; set; } = string.Empty;

        [JsonProperty]
        public static string EVENT { get; set; } = string.Empty;
        [JsonProperty]
        public static string FORMAT_JSON { get; set; } = string.Empty;

    }
}
