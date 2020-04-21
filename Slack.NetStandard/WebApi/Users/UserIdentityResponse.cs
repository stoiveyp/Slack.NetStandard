using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Users
{
    public class UserIdentityResponse : WebApiResponse
    {
        [JsonProperty("team",NullValueHandling = NullValueHandling.Ignore)]
        public SlackId Team { get; set; }

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public UserIdentity User { get; set; }
    }
}