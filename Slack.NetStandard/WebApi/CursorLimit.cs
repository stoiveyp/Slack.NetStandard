using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi
{
    public class CursorLimit
    {
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
    }
}