using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.Interaction
{
    [AcceptedArray]
    public class PayloadAction
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("action_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ActionId { get; set; }

        [JsonProperty("text",NullValueHandling = NullValueHandling.Ignore)]
        public TextObject Text { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("action_ts", NullValueHandling = NullValueHandling.Ignore)]
        public string ActionTimestamp { get; set; }

        [JsonProperty("selected_date", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectedDate { get; set; }

        [JsonProperty("selected_time", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectedTime { get; set; }

        [JsonProperty("selected_option", NullValueHandling = NullValueHandling.Ignore)]
        public IOption SelectedOption { get; set; }

        [JsonProperty("selected_options", NullValueHandling = NullValueHandling.Ignore),AcceptedArray]
        public IOption[] SelectedOptions { get; set; }

        [JsonProperty("selected_user", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectedUser { get; set; }

        [JsonProperty("selected_users", NullValueHandling = NullValueHandling.Ignore)]
        public string[] SelectedUsers { get; set; }

        [JsonProperty("selected_channel", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectedChannel { get; set; }

        [JsonProperty("selected_channels", NullValueHandling = NullValueHandling.Ignore)]
        public string[] SelectedChannels { get; set; }

        [JsonProperty("selected_conversation", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectedConversation { get; set; }

        [JsonProperty("selected_conversations", NullValueHandling = NullValueHandling.Ignore)]
        public string[] SelectedConversations { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }
    }
}