using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public class ViewContainer
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("view_id")]
        public string ViewId { get; set; }
    }
}