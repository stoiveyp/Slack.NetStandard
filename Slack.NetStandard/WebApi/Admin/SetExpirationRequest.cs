using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class SetExpirationRequest:TeamUserRequest
    {
        [JsonProperty("expiration_ts")]
        public long ExpirationTimestamp { get; set; }

    }
}