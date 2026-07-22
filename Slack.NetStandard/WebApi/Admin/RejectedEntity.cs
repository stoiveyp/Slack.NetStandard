using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class RejectedEntity
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("error")]
    public string Error { get; set; }
}