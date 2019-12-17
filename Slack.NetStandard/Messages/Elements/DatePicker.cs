using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class DatePicker:IMessageElement
    {
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
