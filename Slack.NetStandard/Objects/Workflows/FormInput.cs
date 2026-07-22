using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Workflows;

public class FormInput
{
    [JsonProperty("required", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Required { get; set; } = new();

    [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
    public List<FormElement> Elements { get; set; } = new();

    public bool ShouldSerializeRequired() => Required?.Any() ?? false;
    public bool ShouldSerializeElements() => Elements?.Any() ?? false;
}