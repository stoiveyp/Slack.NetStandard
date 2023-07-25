using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Calls;

public class SlackCallUser:CallUser
{
    [JsonProperty("slack_id")]
    public string SlackId { get; set; }
}