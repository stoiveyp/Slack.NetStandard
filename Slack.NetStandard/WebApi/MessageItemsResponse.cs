using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.WebApi
{
    public class MessageItemsResponse:WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("items",NullValueHandling = NullValueHandling.Ignore)]
        public Message[] Items { get; set; }
    }
}
