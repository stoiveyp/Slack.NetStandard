using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps
{
    public class DatastoreItemResponse:WebApiResponse
    {
        [JsonProperty("datastore")]
        public string Datastore { get; set; }

        [JsonProperty("item",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,object> Item { get; set; }
    }
}
