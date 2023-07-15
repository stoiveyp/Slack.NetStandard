using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class SetConversationPrefsRequest
{
    [JsonProperty("who_can_post",NullValueHandling = NullValueHandling.Ignore)]
    public string WhoCanPost { get; set; }

    [JsonProperty("can_thread",NullValueHandling = NullValueHandling.Ignore)]
    public string CanThread { get; set; }

    [JsonProperty("can_huddle",NullValueHandling = NullValueHandling.Ignore)]
    public bool? CanHuddle { get; set; }

    [JsonProperty("enable_at_channel",NullValueHandling = NullValueHandling.Ignore)]
    public bool? EnableAtChannel { get; set; }

    [JsonProperty("enable_at_here",NullValueHandling = NullValueHandling.Ignore)]
    public bool? EnableAtHere { get; set; }
}