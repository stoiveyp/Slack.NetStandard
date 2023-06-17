using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class BarrierResponse : WebApiResponse
{
    [JsonProperty("barrier", NullValueHandling = NullValueHandling.Ignore)]
    public Barrier Barrier { get; set; }
}