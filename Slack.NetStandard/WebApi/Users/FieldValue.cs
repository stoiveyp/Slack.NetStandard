using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Users
{
    public class FieldValue
    {
        public FieldValue(){}

        public FieldValue(string value, string alt = null)
        {
            Value = value;
            Alt = alt;
        }

        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("alt",NullValueHandling = NullValueHandling.Ignore)]
        public string Alt { get; set; }
    }
}