using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    public class BooleanEditOptions
    {
        [JsonProperty("input_type")]
        public string InputType { get; set; }
    }
}