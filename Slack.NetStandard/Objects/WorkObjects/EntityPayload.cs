using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayload<T> where T: EntityPayloadField
    {
        [JsonProperty("attributes")]
        public EntityPayloadAttributes Attributes { get; set; }

        [JsonProperty("fields")]
        public T Fields { get; set; }

        [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        public List<EntityPayloadCustomField> CustomFields = [];

        [JsonProperty("display_order", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> DisplayOrder = [];

        public bool ShouldSerializeDisplayOrder() => DisplayOrder?.Count > 0;
        public bool ShouldSerializeCustomFields() => CustomFields?.Count > 0;
    }
}