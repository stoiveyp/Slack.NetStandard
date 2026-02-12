using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Objects.WorkObjects.Fields;

namespace Slack.NetStandard.Objects.WorkObjects
{
    [JsonConverter(typeof(EntityPayloadFieldConverter))]
    public class EntityPayloadField
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Type { get; set; }

        [JsonProperty("edit", NullValueHandling = NullValueHandling.Ignore)]
        public EditOptions Edit { get; set; }
    }
}