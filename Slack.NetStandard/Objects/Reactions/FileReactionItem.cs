using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Reactions;

public class FileReactionItem : ReactionItem
{
    [JsonProperty("file", NullValueHandling = NullValueHandling.Ignore)]
    public File File { get; set; }
}