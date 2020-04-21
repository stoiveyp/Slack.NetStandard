using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Usergroups
{
    public class UsergroupUserListResponse : WebApiResponse
    {
        [JsonProperty("users",NullValueHandling = NullValueHandling.Ignore)]
        public string[] Users { get; set; }
    }
}