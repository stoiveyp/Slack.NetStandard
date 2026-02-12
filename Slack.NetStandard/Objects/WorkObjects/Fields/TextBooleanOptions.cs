using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    public class TextBooleanOptions : BooleanOptions
    {
        public const string TypeName = "text";

        public override string Type => TypeName;

        [JsonProperty("true_text")]
        public string TrueText { get; set; }

        [JsonProperty("false_text")]
        public string FalseText { get; set; }

        [JsonProperty("true_description", NullValueHandling = NullValueHandling.Ignore)]
        public string TrueDescription { get; set; }

        [JsonProperty("false_description", NullValueHandling = NullValueHandling.Ignore)]
        public string FalseDescription { get; set; }
    }
}