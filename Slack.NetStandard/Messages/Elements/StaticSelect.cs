using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class StaticSelect:IMessageElement
    {
        public StaticSelect(){}

        public StaticSelect(string actionId)
        {
            ActionId = actionId;
        }

        public StaticSelect(string actionId, string placeholder, params Option[] options):this(actionId)
        {
            Placeholder = placeholder;
            Options = options.ToList();
        }

        public StaticSelect(string actionId, string placeholder, params OptionGroup[] optionGroups) : this(actionId)
        {
            Placeholder = placeholder;
            OptionGroups = optionGroups.ToList();
        }

        public const string ElementType = "static_select";

        [JsonProperty("type")] public string Type => ElementType;

        [JsonProperty("placeholder")]
        public PlainText Placeholder { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("options",NullValueHandling = NullValueHandling.Ignore)]
        public IList<Option> Options { get; set; }

        [JsonProperty("option_groups",NullValueHandling = NullValueHandling.Ignore)]
        public IList<OptionGroup> OptionGroups { get; set; }

        [JsonProperty("initial_option",NullValueHandling = NullValueHandling.Ignore)]
        public IOption InitialOption { get; set; }

        [JsonProperty("confirm",NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }

        [JsonProperty("focus_on_load", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FocusOnLoad { get; set; }
    }
}