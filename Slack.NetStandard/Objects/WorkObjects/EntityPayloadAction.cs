using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.Objects.WorkObjects;

public class EntityPayloadAction
{
    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("action_id")]
    public string ActionId { get; set; }

    [JsonProperty("style", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public PayloadActionStyle? Style { get; set; }

    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public string Value { get; set; }

    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public string Url { get; set; }

    [JsonProperty("accessibility_label", NullValueHandling = NullValueHandling.Ignore)]
    public string AccessibilityLabel { get; set; }

    [JsonProperty("processing_state", NullValueHandling = NullValueHandling.Ignore)]
    public ProcessingState ProcessingState { get; set; }
}
