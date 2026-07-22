using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists.SchemaOptions
{
    public class ChoiceOptionSchema
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}