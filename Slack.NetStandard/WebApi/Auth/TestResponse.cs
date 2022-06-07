using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Auth
{
    public class TestResponse : WebApiResponse
    {
        [JsonProperty("url",NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("team",NullValueHandling = NullValueHandling.Ignore)]
        public string Team { get; set; }

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        [JsonProperty("user_id",NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("bot_id",NullValueHandling = NullValueHandling.Ignore)]
        public string BotId { get; set; }
    }
}