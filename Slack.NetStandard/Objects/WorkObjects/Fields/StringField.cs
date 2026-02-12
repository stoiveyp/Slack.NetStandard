using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields;

public class StringField : EntityPayloadField
{
    public const string TypeName = "string";

    public override string Type => TypeName;
    public StringField(string value) { Value = value; }
    public string Value { get; set; }

    [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
    public EntityPayloadIcon Icon { get; set; }

    [JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
    public string Link { get; set; }

    [JsonProperty("tag_color", NullValueHandling = NullValueHandling.Ignore)]
    public string TagColor { get; set; }

    [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
    public string Format { get; set; }

    [JsonProperty("long", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Long { get; set; }
}
