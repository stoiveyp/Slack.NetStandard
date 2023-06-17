using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class ListBarrierResponse : WebApiResponse
{
    [JsonProperty("barriers",NullValueHandling = NullValueHandling.Ignore)]
    public Barrier[] Barriers { get; set; }
}