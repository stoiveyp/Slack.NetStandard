using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements.RichText;
using System.Linq;

namespace Slack.NetStandard.Messages.Elements
{
    public class RichTextInput : IMessageElement
    {
        public const string ElementType = "rich_text_input";
        public string Type => ElementType;

        public RichTextInput() { }

        public RichTextInput(string actionId)
        {
            ActionId = actionId;
        }

        [JsonProperty("action_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ActionId { get; set; }

        [JsonProperty("dispatch_action_config", NullValueHandling = NullValueHandling.Ignore)]
        public DispatchActionConfig DispatchActionConfig { get; set; }

        [JsonProperty("initial_value", NullValueHandling = NullValueHandling.Ignore)]
        public Blocks.RichText InitialValue { get; set; }

        [JsonProperty("focus_on_load", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FocusOnLoad { get; set; }

        [JsonProperty("placeholder", NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Placeholder { get; set; }
    }
}
