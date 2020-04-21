using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Teams
{
    public class IntegrationLog
    {
        [JsonProperty("service_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceId { get; set; }

        [JsonProperty("service_type",NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceType { get; set; }

        [JsonProperty("app_id",NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("app_type",NullValueHandling = NullValueHandling.Ignore)]
        public string AppType { get; set; }

        [JsonProperty("user_id",NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("user_name",NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("date",NullValueHandling = NullValueHandling.Ignore)]
        public long? Date { get; set; }

        [JsonProperty("change_type",NullValueHandling = NullValueHandling.Ignore)]
        public string ChangeType { get; set; }

        [JsonProperty("scope",NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; set; }

        [JsonProperty("reason",NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; set; }

        [JsonProperty("rss_feed",NullValueHandling = NullValueHandling.Ignore)]
        public bool? RssFeed { get; set; }

        [JsonProperty("rss_feed_change_type",NullValueHandling = NullValueHandling.Ignore)]
        public string RssFeedChangeType { get; set; }

        [JsonProperty("rss_feed_title",NullValueHandling = NullValueHandling.Ignore)]
        public string RssFeedTitle { get; set; }

        [JsonProperty("rss_feed_url",NullValueHandling = NullValueHandling.Ignore)]
        public string RssFeedUrl { get; set; }
    }
}