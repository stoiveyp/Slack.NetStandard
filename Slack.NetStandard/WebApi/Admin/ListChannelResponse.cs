using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class ListChannelResponse:WebApiResponse
{
    [JsonProperty("channels",NullValueHandling = NullValueHandling.Ignore)]
    public IdpGroupChannel[] Channels { get; set; }
}