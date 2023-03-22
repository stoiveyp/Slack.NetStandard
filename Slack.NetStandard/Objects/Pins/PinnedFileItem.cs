using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Pins;

public class PinnedFileItem:PinnedItem
{
    [JsonProperty("file",NullValueHandling = NullValueHandling.Ignore)]
    public File File { get; set; }
}