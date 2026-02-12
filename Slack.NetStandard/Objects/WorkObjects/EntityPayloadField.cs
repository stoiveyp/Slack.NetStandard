using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Objects.WorkObjects
{
    [JsonConverter(typeof(EntityPayloadFieldConverter))]
    public class EntityPayloadField
    {
        [JsonProperty("type", NullValueHandling =NullValueHandling.Ignore)] 
        public virtual string Type { get; set; }
    }
}