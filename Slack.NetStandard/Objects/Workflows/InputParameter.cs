using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Workflows;

public class InputParameter
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }

    [JsonProperty("is_required",NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsRequired { get; set; }

    [JsonProperty("is_hidden",NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsHidden { get; set; }
}