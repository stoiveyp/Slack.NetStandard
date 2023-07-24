using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Calls;

public class ExternalCallUser : CallUser
{
    [JsonProperty("external_id",NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalId { get; set; }

    [JsonProperty("display_name",NullValueHandling = NullValueHandling.Ignore)]
    public string DisplayName { get; set; }

    [JsonProperty("avatar_url",NullValueHandling = NullValueHandling.Ignore)]
    public string AvatarUrl { get; set; }
}