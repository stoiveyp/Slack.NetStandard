using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Auth
{
    public class RevokedResponse:WebApiResponse
    {
        [JsonProperty("revoked",NullValueHandling = NullValueHandling.Ignore)]
        public bool Revoked { get; set; }
    }
}
