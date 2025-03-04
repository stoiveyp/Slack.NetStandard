using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class AssistantThreadToken
    {
        [JsonProperty("action_token", NullValueHandling =NullValueHandling.Ignore)]
        public string ActionToken { get; set; }
    }
}