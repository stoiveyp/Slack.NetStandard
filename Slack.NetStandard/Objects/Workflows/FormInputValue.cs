using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Workflows;

public class FormInputValue : StepInput
{
    [JsonProperty("value",NullValueHandling = NullValueHandling.Ignore)]
    public FormInput Value { get; set; }
}