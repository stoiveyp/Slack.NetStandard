using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Calls;

public class CallResponse : WebApiResponse
{
    [JsonProperty("call",NullValueHandling = NullValueHandling.Ignore)]
    public Call Call { get; set; }
}