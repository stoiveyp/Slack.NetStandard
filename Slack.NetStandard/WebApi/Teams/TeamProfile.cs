using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Teams
{
    public class TeamProfile
    {
        [JsonProperty("fields",NullValueHandling = NullValueHandling.Ignore), AcceptedArray]
        public TeamProfileField[] Fields { get; set; }
    }
}