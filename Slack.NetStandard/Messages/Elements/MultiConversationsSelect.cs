using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.Messages.Elements
{
    public class MultiConversationsSelect : IMessageElement
    {
        public MultiConversationsSelect(){}

        public MultiConversationsSelect(string actionId, string placeholder)
        {
            ActionId = actionId;
            Placeholder = placeholder;
        }

        public const string ElementType = "multi_conversations_select";
        [JsonProperty("type")] public string Type => ElementType;

        [JsonProperty("placeholder")]
        public PlainText Placeholder { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("initial_conversations", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> InitialConversation { get; set; } = new List<string>();

        [JsonProperty("confirm", NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }

        [JsonProperty("max_selected_items", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxSelectedItems { get; set; }

        [JsonProperty("filter",NullValueHandling = NullValueHandling.Ignore)]
        public Filter Filter { get; set; }

        [JsonProperty("focus_on_load", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FocusOnLoad { get; set; }

        public bool ShouldSerializeInitialConversation() => InitialConversation?.Any() ?? false;
    }
}