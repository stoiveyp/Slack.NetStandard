using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi
{
    public class MessageItemsResponse:WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("items",NullValueHandling = NullValueHandling.Ignore)]
        public MessageItem[] Items { get; set; }
    }
}
