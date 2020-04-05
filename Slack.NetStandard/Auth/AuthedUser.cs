using Newtonsoft.Json;

namespace Slack.NetStandard.Auth
{
    public class AuthedUser
    {
        [JsonProperty("access_token", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; set; }

        [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; set; }

        [JsonProperty("token_type",NullValueHandling = NullValueHandling.Ignore)]
        public string TokenType { get; set; }

        [JsonProperty("id",NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }
}