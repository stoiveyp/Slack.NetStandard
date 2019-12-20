using Newtonsoft.Json;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.Interaction
{
    public class View
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("close",NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Close { get; set; }

        [JsonProperty("submit", NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Submit { get; set; }

        [JsonProperty("blocks",NullValueHandling = NullValueHandling.Ignore)]
        public IMessageBlock[] Blocks { get; set; }

        [JsonProperty("clear_on_close",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ClearOnClose { get; set; }

        [JsonProperty("notify_on_submit",NullValueHandling = NullValueHandling.Ignore)]
        public bool? NotifyOnSubmit { get; set; }

        [JsonProperty("external_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalId { get; set; }

        [JsonProperty("callback_id",NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackId { get; set; }
    }
}