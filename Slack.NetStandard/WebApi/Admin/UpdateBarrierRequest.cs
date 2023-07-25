using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class UpdateBarrierRequest : CreateBarrierRequest
{
    [JsonProperty("barrier_id")]
    public string BarrierId { get; set; }
}