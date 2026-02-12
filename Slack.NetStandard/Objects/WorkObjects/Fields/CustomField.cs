using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    public class CustomField:EntityPayloadField
    {
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }
}