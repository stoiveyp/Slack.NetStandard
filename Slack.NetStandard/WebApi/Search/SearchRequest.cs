using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Search
{
    public class SearchRequest
    {
        [JsonProperty("query",NullValueHandling = NullValueHandling.Ignore)]
        public string Query { get; set; }

        [JsonProperty("count",NullValueHandling = NullValueHandling.Ignore)]
        public int? Count { get; set; }

        [JsonProperty("highlight",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Highlight { get; set; }

        [JsonProperty("page",NullValueHandling = NullValueHandling.Ignore)]
        public long? Page { get; set; }

        [JsonProperty("sort",NullValueHandling = NullValueHandling.Ignore)]
        public string Sort { get; set; }

        [JsonProperty("sort_dir",NullValueHandling = NullValueHandling.Ignore)]
        public string SortDirection { get; set; }
    }
}