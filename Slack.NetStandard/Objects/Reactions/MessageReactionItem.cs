using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.Objects.Reactions;

public class MessageReactionItem : ReactionItem
{
    [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
    public Message Message { get; set; }
}