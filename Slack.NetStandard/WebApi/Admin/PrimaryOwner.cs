using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class PrimaryOwner
    {
        [JsonProperty("user_id",NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("email",NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
    }
}