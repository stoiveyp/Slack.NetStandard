using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Pins;

public class FilePinnedItem:PinnedItem
{
    [JsonProperty("file",NullValueHandling = NullValueHandling.Ignore)]
    public File File { get; set; }
}