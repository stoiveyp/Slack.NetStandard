using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Users
{
    public class UserResponse:WebApiResponse
    {
        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public User User { get; set; }
    }
}