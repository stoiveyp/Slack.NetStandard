using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.Socket
{
    public class HelloConnectionInformation
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}