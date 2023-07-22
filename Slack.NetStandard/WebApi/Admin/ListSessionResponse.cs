using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class ListSessionResponse:WebApiResponse<ResponseMetadataCursor>
{
    [JsonProperty("active_sessions",NullValueHandling = NullValueHandling.Ignore)]
    public ActiveSession[] ActiveSessions { get; set; }
}