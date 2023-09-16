using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class StringFormElement : TypedFormElement<string>
{
    public StringFormElement()
    {
        Type = WorkflowTypes.BuiltInTypes.String;
    }

    [JsonProperty("minLength",NullValueHandling = NullValueHandling.Ignore)]
    public int? MinLength { get; set; }

    [JsonProperty("maxLength",NullValueHandling = NullValueHandling.Ignore)]
    public int? MaxLength { get; set; }

    [JsonProperty("format",NullValueHandling = NullValueHandling.Ignore)]
    public string Format { get; set; }

    [JsonProperty("enum", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Enum { get; set; } = new();

    [JsonProperty("choices", NullValueHandling = NullValueHandling.Ignore)]
    public List<EnumChoice<string>> Choices { get; set; } = new();

    [JsonProperty("long",NullValueHandling = NullValueHandling.Ignore)]
    public bool? Long { get; set; }

    public bool ShouldSerializeEnum() => Enum?.Any() ?? false;
    public bool ShouldSerializeChoices() => Choices?.Any() ?? false;
}