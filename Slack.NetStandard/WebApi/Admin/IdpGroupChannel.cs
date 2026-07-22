using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class IdpGroupChannel
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
    public string TeamId { get; set; }

    [JsonProperty("is_redacted",NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsRedacted { get; set; }

    [JsonProperty("num_members",NullValueHandling = NullValueHandling.Ignore)]
    public int? NumMembers { get; set; }
}