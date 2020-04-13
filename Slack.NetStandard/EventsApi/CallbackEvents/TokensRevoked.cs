using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class TokensRevoked : CallbackEvent
    {
        public const string EventType = "tokens_revoked";

        [JsonProperty("tokens",NullValueHandling = NullValueHandling.Ignore)]
        public TokenRevokedInformation Tokens { get; set; }
    }
}