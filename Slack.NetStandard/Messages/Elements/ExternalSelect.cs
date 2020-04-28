using System.Collections.Generic;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class ExternalSelect:IMessageElement
    {
        public const string ElementType = "external_select";
        [JsonProperty("type")] public string Type => ElementType;

        [JsonProperty("placeholder")]
        public PlainText Placeholder { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("initial_option",NullValueHandling = NullValueHandling.Ignore)]
        public IOption InitialOption { get; set; }

        [JsonProperty("min_query_length",NullValueHandling = NullValueHandling.Ignore)]
        public int? MinimumQueryLength { get; set; }

        [JsonProperty("confirm",NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }
    }

    public class MultiExternalSelect : IMessageElement
    {
        public const string ElementType = "multi_external_select";
        [JsonProperty("type")] public string Type => ElementType;

        [JsonProperty("placeholder")]
        public PlainText Placeholder { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("initial_options", NullValueHandling = NullValueHandling.Ignore)]
        public IOption[] InitialOptions { get; set; }

        [JsonProperty("min_query_length", NullValueHandling = NullValueHandling.Ignore)]
        public int? MinimumQueryLength { get; set; }

        [JsonProperty("confirm", NullValueHandling = NullValueHandling.Ignore)]
        public Confirmation Confirm { get; set; }

        [JsonProperty("max_selected_items",NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxSelectedItems { get; set; }

    }
}