using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class ShortcutFeature
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("callback_id")]
    public string CallbackId { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
}