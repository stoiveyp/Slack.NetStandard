using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Bots
{
    public class BotInfo
    {
        [JsonProperty("id",NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }

        [JsonProperty("deleted",NullValueHandling = NullValueHandling.Ignore)]
        public bool Deleted { get; set; }

        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("updated",NullValueHandling = NullValueHandling.Ignore)]
        public long Updated { get; set; }

        [JsonProperty("app_id",NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("user_id",NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("icons",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,string> Icons { get; set; }
    }
}