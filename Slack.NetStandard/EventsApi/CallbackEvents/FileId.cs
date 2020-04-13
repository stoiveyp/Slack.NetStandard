using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class FileId
    {
        [JsonProperty("id")]
        public string ID { get; set; }
    }
}