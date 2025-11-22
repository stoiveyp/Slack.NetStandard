using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListsItemInfoResponse:WebApiResponse
    {
        [JsonProperty("list", NullValueHandling = NullValueHandling.Ignore)]
        public SlackListsList List { get; set; }
    }
}
