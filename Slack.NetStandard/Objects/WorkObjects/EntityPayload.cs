using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayload
    {
        [JsonProperty("attributes")]

        [JsonProperty("fields")]

        [JsonProperty("custom_fields")]

        [JsonProperty("display_order")]
    }

    //https://docs.slack.dev/messaging/work-objects#entity-payload-schema
}