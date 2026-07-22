using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Calls;

public class UpdateCallRequest
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("desktop_app_join_url",NullValueHandling = NullValueHandling.Ignore)]
    public string DesktopAppJoinUrl { get; set; }

    [JsonProperty("join_url",NullValueHandling = NullValueHandling.Ignore)]
    public string JoinUrl { get; set; }

    [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }
}