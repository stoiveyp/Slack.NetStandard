using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements;

public class Url : IMessageElement
{
    public static string ElementType = "url_text_input";
    public string Type => ElementType;

    public Url() { }

    public Url(string actionId)
    {
        ActionId = actionId;
    }

    public Url(string actionId, string initialValue) : this(actionId)
    {
        InitialValue = initialValue;
    }

    [JsonProperty("action_id",NullValueHandling = NullValueHandling.Ignore)]
    public string ActionId { get; set; }

    [JsonProperty("placeholder",NullValueHandling = NullValueHandling.Ignore)]
    public PlainText Placeholder { get; set; }

    [JsonProperty("initial_value",NullValueHandling = NullValueHandling.Ignore)]
    public string InitialValue { get; set; }

    [JsonProperty("dispatch_action_config",NullValueHandling = NullValueHandling.Ignore)]
    public DispatchActionConfig DispatchActionConfig { get; set; }

    [JsonProperty("focus_on_load",NullValueHandling = NullValueHandling.Ignore)]
    public bool? FocusOnLoad { get; set; }
}