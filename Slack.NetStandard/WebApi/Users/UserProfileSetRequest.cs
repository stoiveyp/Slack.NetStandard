using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Users
{
    public class UserProfileSetRequest
    {
        [JsonProperty("profile")]
        public UserProfileSet Profile { get; set; }
    }
}