using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ListedTeam
    {
        [JsonProperty("id",NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }

        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("discoverability",NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public TeamDiscoverability Discoverability { get; set; }

        [JsonProperty("primary_owner",NullValueHandling = NullValueHandling.Ignore)]
        public PrimaryOwner PrimaryOwner { get; set; }
    }
}