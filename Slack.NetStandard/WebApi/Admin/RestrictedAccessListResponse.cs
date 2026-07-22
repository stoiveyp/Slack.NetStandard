using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class RestrictedAccessListResponse:WebApiResponse
{
    [JsonProperty("group_ids",NullValueHandling = NullValueHandling.Ignore)]
    public string[] GroupIds { get; set; }
}