using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.Messages.Blocks;

public class ContextActions : IMessageBlock
{
    public const string MessageBlockType = "context_actions";
    public ContextActions(){}

    public ContextActions(params IContextActionsElement[] elements)
    {
        Elements = elements.ToList();
    }

    public string Type => MessageBlockType;

    [JsonProperty("block_id",NullValueHandling = NullValueHandling.Ignore)]
    public string BlockId { get; set; }

    [JsonProperty("elements",NullValueHandling = NullValueHandling.Ignore)]
    public IList<IContextActionsElement> Elements { get; set; } = new List<IContextActionsElement>();

    public bool ShouldSerializeElements() => Elements.Any();
}