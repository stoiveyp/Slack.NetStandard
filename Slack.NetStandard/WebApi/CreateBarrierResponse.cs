using Newtonsoft.Json;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

public class CreateBarrierResponse:WebApiResponse
{
    [JsonProperty("barrier",NullValueHandling = NullValueHandling.Ignore)]
    public Barrier Barrier { get; set; }
}