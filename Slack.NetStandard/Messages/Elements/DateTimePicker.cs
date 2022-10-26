using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements;

public class DateTimePicker : IMessageElement
{
    public static string ElementType = "datetimepicker";
    public string Type => ElementType;

    public DateTimePicker() { }

    public DateTimePicker(string actionId)
    {
        ActionId = actionId;
    }

    public DateTimePicker(string actionId, long initialDateTime) : this(actionId)
    {
        InitialDateTime = initialDateTime;
    }

    [JsonProperty("action_id")]
    public string ActionId { get; set; }

    [JsonProperty("initial_date_time",NullValueHandling = NullValueHandling.Ignore)]
    public long? InitialDateTime { get; set; }

    [JsonProperty("confirm",NullValueHandling = NullValueHandling.Ignore)]
    public Confirmation Confirm { get; set; }

    [JsonProperty("focus_on_load",NullValueHandling = NullValueHandling.Ignore)]
    public bool? FocusOnLoad { get; set; }
}