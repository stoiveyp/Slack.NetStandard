using System;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Users
{
    public class UserProfileResponse:WebApiResponse
    {
        [JsonProperty("profile",NullValueHandling = NullValueHandling.Ignore)]
        public UserProfile Profile { get; set; }
    }
}
