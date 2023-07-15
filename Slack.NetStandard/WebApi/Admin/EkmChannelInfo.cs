using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class EkmChannelInfo
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("internal_team_ids"),AcceptedArray]
    public string[] InternalTeamIds { get; set; }

    [JsonProperty("original_connected_host_id")]
    public string OriginalConnectedHostId { get; set; }

    [JsonProperty("original_connected_channel_id")]
    public string OriginalConnectedChannelId { get; set; }
}