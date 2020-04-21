using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi
{
    public class ChannelListResponse:WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("channels",NullValueHandling = NullValueHandling.Ignore)]
        public Channel[] Channels { get; set; }
    }
}