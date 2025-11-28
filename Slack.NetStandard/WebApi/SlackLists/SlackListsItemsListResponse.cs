using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListsItemsListResponse: WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("items")]
        [AcceptedArray]
        public SlackListsItem[] Items { get; set; }
    }
}
