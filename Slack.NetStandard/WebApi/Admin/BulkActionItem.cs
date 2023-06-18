using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class BulkActionItem
{
    [JsonProperty("channel_id")]
    public string ChannelId { get; set; }

    [JsonProperty("error")]
    public string Error { get; set; }
}