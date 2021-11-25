using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class RadioButtons:IMessageElement
    {
        public RadioButtons(){}

        public RadioButtons(string actionId, params Option[] options)
        {
            ActionId = actionId;
            Options = options.ToList();
        }

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

        [JsonProperty("focus_on_load", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FocusOnLoad { get; set; }
    }
}
