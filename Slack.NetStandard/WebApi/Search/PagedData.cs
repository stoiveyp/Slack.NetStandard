using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Search
{
    public class PagedData<T>
    {
        [JsonProperty("matches",NullValueHandling = NullValueHandling.Ignore)]
        public T[] Matches { get; set; }

        [JsonProperty("paging",NullValueHandling = NullValueHandling.Ignore)]
        public Paging Paging { get; set; }

        [JsonProperty("pagination",NullValueHandling = NullValueHandling.Ignore)]
        public Pagination Pagination { get; set; }

        [JsonProperty("total",NullValueHandling = NullValueHandling.Ignore)]
        public long Total { get; set; }
    }
}