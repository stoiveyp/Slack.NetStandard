using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class Metadata
{
    [JsonProperty("major_version", NullValueHandling = NullValueHandling.Ignore)]
    public int? MajorVersion { get; set; }

    [JsonProperty("minor_version", NullValueHandling = NullValueHandling.Ignore)]
    public int? MinorVersion { get; set; }
}