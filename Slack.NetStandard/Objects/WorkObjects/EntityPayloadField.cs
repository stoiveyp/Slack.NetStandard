using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayloadField
    {
        [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
        public EntityPayloadFieldUser CreatedBy { get; set; }

        [JsonProperty("date_created", NullValueHandling = NullValueHandling.Ignore)]
        public EntityPayloadFieldTimestamp DateCreated { get; set; }

        [JsonProperty("date_updated", NullValueHandling = NullValueHandling.Ignore)]
        public EntityPayloadFieldTimestamp DateUpdated { get; set; }

        [JsonProperty("last_modified_by")]
        public EntityPayloadFieldUser LastModifiedBy { get; set; }



    }
}