using System.Collections.Generic;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class ExternalSelect:IMessageElement
    {
        [JsonProperty("type")] public string Type => "external_select";

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
}