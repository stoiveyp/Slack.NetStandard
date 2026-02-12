using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    public class TextEditOptions
    {
        [JsonProperty("min_length", NullValueHandling = NullValueHandling.Ignore)]
        public int? MinLength { get; set; }

        [JsonProperty("max_length", NullValueHandling = NullValueHandling.Ignore)] 
        public int? MaxLength { get; set; }
    }
}