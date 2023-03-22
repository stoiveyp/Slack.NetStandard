using Newtonsoft.Json;
using Slack.NetStandard.Objects.Pins;

namespace Slack.NetStandard.WebApi.Pins
{
    public class PinnedListResponse : WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public PinnedItem[] Items { get; set; }
    }
}
