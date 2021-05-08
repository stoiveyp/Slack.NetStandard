using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.Messages.Elements
{
    public class Button:IMessageElement
    {
        public Button(){}

        public Button(string text, string actionId)
        {
            Text = text;
            ActionId = actionId;
        }

        [JsonProperty("type")]
        public string Type => nameof(Button).ToLower();

        [JsonProperty("text",NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Text { get; set; }

        [JsonProperty("action_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ActionId { get; set; }

        [JsonProperty("url",NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("value",NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("style",NullValueHandling = NullValueHandling.Ignore),
        JsonConverter(typeof(StringEnumConverter))]
        public ButtonStyle? Style { get; set; }

        [JsonProperty("confirm",NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }
    }
}
