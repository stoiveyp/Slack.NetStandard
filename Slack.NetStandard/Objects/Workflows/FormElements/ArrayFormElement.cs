using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class ArrayFormElement : FormElement
{
    public ArrayFormElement()
    {
        Type = WorkflowTypes.BuiltInTypes.Array;
    }

    [JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
    public List<FormElement> Default { get; set; } = new();

    [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
    public List<FormElement> Items { get; set; } = new();

    public bool ShouldSerializeItems() => Items?.Any() ?? false;
    public bool ShouldSerializeDefault() => Default?.Any() ?? false;
}

