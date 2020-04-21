using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Teams
{
    public class Login
    {
        [JsonProperty("user_id",NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("username",NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("date_first",NullValueHandling = NullValueHandling.Ignore)]
        public long DateFirst { get; set; }

        [JsonProperty("date_last",NullValueHandling = NullValueHandling.Ignore)]
        public long DateLast { get; set; }

        [JsonProperty("count",NullValueHandling = NullValueHandling.Ignore)]
        public int Count { get; set; }

        [JsonProperty("ip",NullValueHandling = NullValueHandling.Ignore)]
        public string IP { get; set; }

        [JsonProperty("user_agent",NullValueHandling = NullValueHandling.Ignore)]
        public string UserAgent { get; set; }

        [JsonProperty("isp",NullValueHandling = NullValueHandling.Ignore)]
        public string ISP { get; set; }

        [JsonProperty("country",NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("region",NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get; set; }
    }
}