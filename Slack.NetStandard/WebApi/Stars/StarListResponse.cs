using Newtonsoft.Json;
using Slack.NetStandard.Objects.Stars;

namespace Slack.NetStandard.WebApi.Stars
{
    public class StarListResponse:WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("items",NullValueHandling = NullValueHandling.Ignore)]
        public StarredItem[] Items { get; set; }
    }
}
