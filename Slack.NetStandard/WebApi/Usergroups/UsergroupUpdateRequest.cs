using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Usergroups
{
    public class UsergroupUpdateRequest : UsergroupCreateRequest
    {
        [JsonProperty("usergroup")]
        public string Usergroup { get; set; }
    }
}