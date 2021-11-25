using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class TimePicker : IMessageElement
    {
        public TimePicker() { }

        public TimePicker(string actionId)
        {
            ActionId = actionId;
        }

        public string Type => nameof(TimePicker).ToLower();

        [JsonProperty("placeholder")]
        public PlainText Placeholder { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("initial_time", NullValueHandling = NullValueHandling.Ignore)]
        public string InitialTime { get; set; }

        [JsonProperty("confirm", NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }

        [JsonProperty("focus_on_load", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FocusOnLoad { get; set; }
    }
}
