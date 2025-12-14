using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Objects.WorkObjects
{
    [JsonConverter(typeof(EntityPayloadFieldConverter))]
    public class EntityPayloadField
    {

    }
}