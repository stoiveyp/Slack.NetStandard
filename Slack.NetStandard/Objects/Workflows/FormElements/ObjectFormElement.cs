using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class ObjectFormElement : TypedFormElement<FormElement>
{
    public ObjectFormElement()
    {
        Type = WorkflowTypes.BuiltInTypes.Object;
    }

    [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, FormElement> Properties { get; set; } = new();

    public bool ShouldSerializeProperties() => Properties?.Any() ?? false;
}