using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.View
{
    internal class TriggerViewRequest
    {
        [JsonProperty("trigger_id")]
        public string Trigger { get; set; }

        [JsonProperty("view")]
        public Objects.View View { get; set; }
    }
}