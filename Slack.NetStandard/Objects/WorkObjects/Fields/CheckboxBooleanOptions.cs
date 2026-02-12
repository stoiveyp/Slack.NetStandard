using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    public class CheckboxBooleanOptions : BooleanOptions
    {
        public const string TypeName = "checkbox";

        public override string Type => TypeName;

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }
}