using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Search
{
    public class Pagination
    {
        [JsonProperty("total_count")]
        public long TotalCount { get; set; }

        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("page_count")]
        public long PageCount { get; set; }

        [JsonProperty("first",NullValueHandling = NullValueHandling.Ignore)]
        public long First { get; set; }

        [JsonProperty("last",NullValueHandling = NullValueHandling.Ignore)]
        public long Last { get; set; }
    }
}