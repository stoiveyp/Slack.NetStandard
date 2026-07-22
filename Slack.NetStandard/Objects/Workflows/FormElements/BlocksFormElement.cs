using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class BlocksFormElement : FormElement
{
    public BlocksFormElement()
    {
        Type = WorkflowTypes.SlackTypes.Blocks;
    }

    [JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
    public List<IMessageBlock> Default { get; set; } = new();

    public bool ShouldSerializeDefault() => Default?.Any() ?? false;
}