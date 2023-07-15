using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class EkmOriginalConnectedRequest
{
    [JsonProperty("channel_ids",NullValueHandling = NullValueHandling.Ignore)]
    public string ChannelIds { get; set; }

    [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
    public string Cursor { get; set; }

    [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    [JsonProperty("team_ids",NullValueHandling = NullValueHandling.Ignore)]
    public string TeamIds { get; set; }
}