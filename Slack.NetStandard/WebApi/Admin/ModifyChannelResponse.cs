using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class ModifyChannelResponse : WebApiResponse
{
    [JsonProperty("invalid_channels",NullValueHandling = NullValueHandling.Ignore)]
    public string[] InvalidChannels { get; set; }
}