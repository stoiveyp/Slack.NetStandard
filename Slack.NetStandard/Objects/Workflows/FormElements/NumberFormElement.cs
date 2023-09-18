using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class NumberFormElement : StructFormElement<long>
{
    public NumberFormElement()
    {
        Type = WorkflowTypes.BuiltInTypes.Number;
    }

    [JsonProperty("minimum", NullValueHandling = NullValueHandling.Ignore)]
    public long? Minimum { get; set; }

    [JsonProperty("maximum", NullValueHandling = NullValueHandling.Ignore)]
    public long? Maximum { get; set; }

    [JsonProperty("enum", NullValueHandling = NullValueHandling.Ignore)]
    public List<long> Enum { get; set; } = new();

    [JsonProperty("choices", NullValueHandling = NullValueHandling.Ignore)]
    public List<EnumChoice<long>> Choices { get; set; } = new();

    public bool ShouldSerializeEnum() => Enum?.Any() ?? false;
    public bool ShouldSerializeChoices() => Choices?.Any() ?? false;
}