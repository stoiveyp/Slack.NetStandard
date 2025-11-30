using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayloadFieldInnerUser
    {
        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

    }
}