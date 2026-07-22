using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Files;

public class CompletedFile
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }
}