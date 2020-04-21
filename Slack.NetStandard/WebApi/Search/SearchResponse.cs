using Newtonsoft.Json;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Search
{
    public class SearchResponse:WebApiResponse
    {
        [JsonProperty("query",NullValueHandling = NullValueHandling.Ignore)]
        public string Query { get; set; }

        [JsonProperty("files",NullValueHandling = NullValueHandling.Ignore)]
        public PagedData<File> Files { get; set; }

        [JsonProperty("messages",NullValueHandling = NullValueHandling.Ignore)]
        public PagedData<Message> Messages { get; set; }
    }
}