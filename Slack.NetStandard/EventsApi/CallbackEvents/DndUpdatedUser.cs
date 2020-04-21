using Newtonsoft.Json;
using Slack.NetStandard.ApiCommon;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class DndUpdatedUser : CallbackEvent
    {
        public const string EventType = "dnd_updated_user";

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("dnd_status", NullValueHandling = NullValueHandling.Ignore)]
        public DndStatus DndStatus { get; set; }
    }
}