using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class EkmOriginalConnectedResponse:WebApiResponse<ResponseMetadataCursor>
{
    [JsonProperty("channels",NullValueHandling = NullValueHandling.Ignore)]
    public EkmChannelInfo[] Channels { get; set; }
}