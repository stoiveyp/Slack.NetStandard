using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi;

public class WebApiError
{
    [JsonProperty("message",NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; set; }

    [JsonProperty("pointer",NullValueHandling = NullValueHandling.Ignore)]
    public string Pointer { get; set; }

    public static explicit operator WebApiError(string msg) => new (){Message=msg};
}