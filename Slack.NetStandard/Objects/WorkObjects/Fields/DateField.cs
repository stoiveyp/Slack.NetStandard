using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields;

public class DateField : EntityPayloadField
{
    public const string TypeName = "slack#/types/date";

    [JsonProperty("type")]
    public override string Type => TypeName;

    [JsonProperty("value")]
    public string Value { get; set; }
}
