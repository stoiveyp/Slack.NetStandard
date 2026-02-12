using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    public class TextEditOptions
    {
        [JsonProperty("min_length")]
        public int MinLength { get; set; }

        [JsonProperty("max_length")] 
        public int MaxLength { get; set; }
    }
}