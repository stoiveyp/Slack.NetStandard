using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class GetTeamsResponse : WebApiResponse<ResponseMetadataCursor>
{
    [JsonProperty("team_ids")]
    public string[] TeamIds { get; set; }
}