using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Search
{
    public class Paging
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("pages")]
        public int Pages { get; set; }
    }
}