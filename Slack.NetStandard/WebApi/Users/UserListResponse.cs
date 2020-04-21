using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Users
{
    public class UserListResponse : WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("members", NullValueHandling = NullValueHandling.Ignore)]
        public User[] Members { get; set; }
    }
}