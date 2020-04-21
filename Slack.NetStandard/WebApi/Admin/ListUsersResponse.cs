using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ListUsersResponse : WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("users", NullValueHandling = NullValueHandling.Ignore)]
        public User[] Teams { get; set; }
    }
}