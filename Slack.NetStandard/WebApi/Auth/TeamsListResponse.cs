using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Auth;

public class TeamsListResponse : WebApiResponse<ResponseMetadataCursor>
{
    [JsonProperty("teams",NullValueHandling = NullValueHandling.Ignore)]
    public SlackId[] Teams { get; set; }
}