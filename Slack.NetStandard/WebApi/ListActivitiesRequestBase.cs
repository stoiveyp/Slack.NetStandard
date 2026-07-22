using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Slack.NetStandard.WebApi.Apps;

namespace Slack.NetStandard.WebApi
{
    public abstract class ListActivitiesRequestBase
    {
        [JsonProperty("component_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ComponentId { get; set; }

        [JsonProperty("component_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ComponentType { get; set; }

        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        [JsonProperty("log_event_type", NullValueHandling = NullValueHandling.Ignore)]
        public string LogEventType { get; set; }

        [JsonProperty("max_date_created", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxDateCreated { get; set; }

        [JsonProperty("min_date_created", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinDateCreated { get; set; }

        [JsonProperty("min_log_level", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public LogLevel MinLogLevel { get; set; }

        [JsonProperty("sort_direction", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public SortDirection SortDirection { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        [JsonProperty("trace_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TraceId { get; set; }
    }
}
