using System.Collections.Generic;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class ConversationsSelect:IMessageElement
    {
        [JsonProperty("type")] public string Type => "conversations_select";

        [JsonProperty("placeholder")]
        public PlainText Placeholder { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("initial_conversation",NullValueHandling = NullValueHandling.Ignore)]
        public string InitialConversation { get; set; }

        [JsonProperty("confirm",NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }
    }
}