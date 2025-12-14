using Newtonsoft.Json;
using Slack.NetStandard.Objects.WorkObjects.Fields;
using System.Collections.Generic;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayload
    {
        [JsonProperty("attributes")]
        public EntityPayloadAttributes Attributes { get; set; }

        [JsonProperty("fields")]
        public Dictionary<string,EntityPayloadField> Fields { get; set; }

        [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        public List<EntityPayloadField> CustomFields = [];

        [JsonProperty("display_order", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> DisplayOrder = [];

        public bool ShouldSerializeDisplayOrder() => DisplayOrder?.Count > 0;
        public bool ShouldSerializeCustomFields() => CustomFields?.Count > 0;
    }
}