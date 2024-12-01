using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.Objects
{
    public class View
    {
        public View(){}

        public View(string type)
        {
            Type = type;
        }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }

        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Title { get; set; }

        [JsonProperty("close",NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Close { get; set; }

        [JsonProperty("submit", NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Submit { get; set; }

        [JsonProperty("blocks", NullValueHandling = NullValueHandling.Ignore)]
        public List<IMessageBlock> Blocks { get; set; } = new();

        [JsonProperty("clear_on_close",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ClearOnClose { get; set; }

        [JsonProperty("notify_on_submit",NullValueHandling = NullValueHandling.Ignore)]
        public bool? NotifyOnSubmit { get; set; }

        [JsonProperty("notify_on_close", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NotifyOnClose { get; set; }

        [JsonProperty("external_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalId { get; set; }

        [JsonProperty("callback_id",NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackId { get; set; }

        [JsonProperty("private_metadata",NullValueHandling = NullValueHandling.Ignore)]
        public string PrivateMetadata { get; set; }

        [JsonProperty("previous_view_id",NullValueHandling = NullValueHandling.Ignore)]
        public string PreviousViewId { get; set; }

        [JsonProperty("root_view_id",NullValueHandling = NullValueHandling.Ignore)]
        public string RootViewId { get; set; }

        [JsonProperty("hash",NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public ViewState State { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }

        public bool ShouldSerializeBlocks() => Blocks.Any();
    }
}