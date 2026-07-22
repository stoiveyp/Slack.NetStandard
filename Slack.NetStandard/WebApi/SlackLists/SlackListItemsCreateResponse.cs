using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListItemsCreateResponse:WebApiResponse
    {
        [JsonProperty("item")]
        public SlackListsItem Item { get; set; }
    }
}
