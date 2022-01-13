using Newtonsoft.Json;
using Slack.NetStandard.Interaction;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard.Auth
{
    public class AccessTokenInformation:WebApiResponse
    {
        [JsonProperty("access_token",NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in",NullValueHandling = NullValueHandling.Ignore)]
        public long? ExpiresIn { get; set; }

        [JsonProperty("refresh_token",NullValueHandling = NullValueHandling.Ignore)]
        public string RefreshToken { get; set; }

        [JsonProperty("scope",NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; set; }

        [JsonProperty("bot_user_id",NullValueHandling = NullValueHandling.Ignore)]
        public string BotUserId { get; set; }

        [JsonProperty("app_id",NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("team",NullValueHandling = NullValueHandling.Ignore)]
        public SlackId Team { get; set; }

        [JsonProperty("enterprise",NullValueHandling = NullValueHandling.Ignore)]
        public SlackId Enterprise { get; set; }

        [JsonProperty("authed_user",NullValueHandling = NullValueHandling.Ignore)]
        public AuthedUser AuthedUser { get; set; }

        [JsonProperty("is_enterprise_install", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsEnterpriseInstall { get; set; }
    }
}
