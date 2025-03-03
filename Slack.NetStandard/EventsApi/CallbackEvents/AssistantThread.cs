using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class AssistantThread
    {
        [JsonProperty("action_token", NullValueHandling =NullValueHandling.Ignore)]
        public string ActionToken { get; set; }
    }
}