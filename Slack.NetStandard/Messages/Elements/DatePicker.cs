using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class DatePicker:IMessageElement
    {
        public DatePicker(){}

        public DatePicker(string actionId)
        {
            ActionId = actionId;
        }

        public DatePicker(string actionId, string initialDate) : this(actionId)
        {
            InitialDate = initialDate;
        }

        [JsonProperty("type")] public string Type => nameof(DatePicker).ToLower();

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("placeholder",NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Placeholder { get; set; }

        [JsonProperty("initial_date",NullValueHandling = NullValueHandling.Ignore)]
        public string InitialDate { get; set; }

        [JsonProperty("confirm", NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }
    }
}
