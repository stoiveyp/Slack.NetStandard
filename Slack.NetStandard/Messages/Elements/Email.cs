using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements;

public class Email : IMessageElement
{
    public static string ElementType = "email_text_input";
    public string Type => ElementType;

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