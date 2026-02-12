using Newtonsoft.Json;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.Objects.WorkObjects;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [JsonProperty("entity_url", NullValueHandling = NullValueHandling.Ignore)]
        public string EntityUrl { get; set; }

        [JsonProperty("external_ref", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalRef ExternalRef { get; set; }

        [JsonProperty("message_ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp MessageTimestamp { get; set; }

        [JsonProperty("thread_ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp ThreadTimestamp { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("app_unfurl_url", NullValueHandling = NullValueHandling.Ignore)]
        public string AppUnfurlUrl { get; set; }

        [JsonProperty("bot_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BotId { get; set; }

        [JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("app_installed_team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppInstalledTeamId { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }

        public bool ShouldSerializeBlocks() => Blocks.Any();
    }
}