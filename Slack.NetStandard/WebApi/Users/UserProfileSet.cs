using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Users
{
    public class UserProfileSet:UserProfile
    {
        [JsonProperty("fields",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,FieldValue> Fields { get; set; }
    }
}