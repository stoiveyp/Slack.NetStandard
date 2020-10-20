using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Apps
{
    public class ListAuthorizationsResponse : WebApiResponse
    {
        [JsonProperty("authorizations", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(AuthorizationConverter))]
        public Authorization[] Authorizations { get; set; }

        [JsonProperty("cursor_next", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }
    }
}
