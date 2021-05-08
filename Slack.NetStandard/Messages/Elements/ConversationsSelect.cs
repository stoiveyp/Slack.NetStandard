using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class ConversationsSelect:IMessageElement
    {
        public ConversationsSelect(){}

        public ConversationsSelect(string actionId, string placeholder)
        {
            ActionId = actionId;
            Placeholder = placeholder;
        }

        public const string ElementType = "conversations_select";
        [JsonProperty("type")] public string Type => ElementType;

        [JsonProperty("placeholder")]
        public PlainText Placeholder { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("initial_conversation",NullValueHandling = NullValueHandling.Ignore)]
        public string InitialConversation { get; set; }

        [JsonProperty("default_to_current_conversation", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DefaultToCurrentConversation { get; set; }

        [JsonProperty("response_url_enabled",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ResponseUrlEnabled { get; set; }

        [JsonProperty("confirm",NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }

        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Filter Filter { get; set; }
    }
}