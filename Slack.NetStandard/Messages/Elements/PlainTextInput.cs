using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class PlainTextInput : IMessageElement
    {
        public PlainTextInput(){}

        public PlainTextInput(string actionId)
        {
            ActionId = actionId;
        }

        public PlainTextInput(string actionId, string initialValue):this(actionId)
        {
            InitialValue = initialValue;
        }

        public const string ElementType = "plain_text_input";

        [JsonProperty("type")] public string Type => ElementType;

        [JsonProperty("action_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ActionId { get; set; }

        [JsonProperty("placeholder",NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Placeholder { get; set; }

        [JsonProperty("initial_value",NullValueHandling = NullValueHandling.Ignore)]
        public string InitialValue { get; set; }

        [JsonProperty("multiline",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Multiline { get; set; }

        [JsonProperty("min_length",NullValueHandling = NullValueHandling.Ignore)]
        public int? MinLength { get; set; }

        [JsonProperty("max_length",NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxLength { get; set; }
    }
}