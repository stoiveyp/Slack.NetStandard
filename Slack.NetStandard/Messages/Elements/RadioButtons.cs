using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class RadioButtons:IMessageElement
    {
        public const string ElementType = "radio_buttons";
        public string Type => ElementType;

        [JsonProperty("action_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ActionId { get; set; }

        [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Option> Options { get; set; }

        [JsonProperty("initial_option", NullValueHandling = NullValueHandling.Ignore)]
        public IOption InitialOption { get; set; }

        [JsonProperty("confirm", NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }
    }
}
