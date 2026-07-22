using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class IntegerFormElement : StructFormElement<int>
{
    public IntegerFormElement()
    {
        Type = WorkflowTypes.BuiltInTypes.Integer;
    }

    [JsonProperty("minimum",NullValueHandling = NullValueHandling.Ignore)]
    public int? Minimum { get; set; }

    [JsonProperty("maximum",NullValueHandling = NullValueHandling.Ignore)]
    public int? Maximum { get; set; }

    [JsonProperty("enum", NullValueHandling = NullValueHandling.Ignore)]
    public List<int> Enum { get; set; } = new();

    [JsonProperty("choices", NullValueHandling = NullValueHandling.Ignore)]
    public List<EnumChoice<int>> Choices { get; set; } = new();

    public bool ShouldSerializeEnum() => Enum?.Any() ?? false;
    public bool ShouldSerializeChoices() => Choices?.Any() ?? false;
}