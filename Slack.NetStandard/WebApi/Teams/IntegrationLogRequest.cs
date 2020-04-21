using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Teams
{
    public class IntegrationLogRequest
    {
        [JsonProperty("app_id",NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("change_type",NullValueHandling = NullValueHandling.Ignore)]
        public string ChangeType { get; set; }

        [JsonProperty("count",NullValueHandling = NullValueHandling.Ignore)]
        public int? Count { get; set; }

        [JsonProperty("page",NullValueHandling = NullValueHandling.Ignore)]
        public int? Page { get; set; }

        [JsonProperty("service_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceId { get; set; }

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }
    }
}