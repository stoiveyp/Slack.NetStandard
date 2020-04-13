using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class MessageDeleted : Message
    {
        public const string MessageSubType = "message_deleted";

        [JsonProperty("deleted_ts")]
        public Timestamp DeletedTimestamp { get; set; }
    }
}