using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Users
{
    public class UserIdentity:SlackId
    {
        [JsonProperty("email",NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("image_24", NullValueHandling = NullValueHandling.Ignore)]
        public string Image24 { get; set; }

        [JsonProperty("image_32", NullValueHandling = NullValueHandling.Ignore)]
        public string Image32 { get; set; }

        [JsonProperty("image_48", NullValueHandling = NullValueHandling.Ignore)]
        public string Image48 { get; set; }

        [JsonProperty("image_72", NullValueHandling = NullValueHandling.Ignore)]
        public string Image72 { get; set; }

        [JsonProperty("image_192", NullValueHandling = NullValueHandling.Ignore)]
        public string Image192 { get; set; }
    }
}