using Newtonsoft.Json;

namespace Slack.NetStandard.ApiCommon
{
    public class TeamSummary:SlackId
    {
        [JsonProperty("domain", NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get; set; }
    }
}