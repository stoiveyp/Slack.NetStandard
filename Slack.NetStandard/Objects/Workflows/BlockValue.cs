using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.Objects.Workflows;

public class BlockValue : StepInput
{
    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public List<IMessageBlock> Value { get; set; } = new();

    public bool ShouldSerializeValue() => Value?.Any() ?? false;
}