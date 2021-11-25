using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class MultiStaticSelect:IMessageElement
    {
        public MultiStaticSelect(){}

        public MultiStaticSelect(string actionId, string placeholder)
        {
            ActionId = actionId;
            Placeholder = placeholder;
        }

        public const string ElementType = "multi_static_select";
        [JsonProperty("type")] public virtual string Type => ElementType;

        [JsonProperty("max_selected_items",NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxSelectedItems { get; set; }

        [JsonProperty("confirm",NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }

        [JsonProperty("placeholder")]
        public PlainText Placeholder { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Option> Options { get; set; }

        [JsonProperty("option_groups", NullValueHandling = NullValueHandling.Ignore)]
        public IList<OptionGroup> OptionGroups { get; set; }

        [JsonProperty("initial_options", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IOption> InitialOption { get; set; }

        [JsonProperty("focus_on_load", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FocusOnLoad { get; set; }
    }
}