using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements;

public class FeedbackButton
{
    public FeedbackButton()
    {
    }
    public FeedbackButton(string text, string value)
    {
        Text = new PlainText(text);
        Value = value;
    }
    [JsonProperty("text")]
    public PlainText Text { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }
        
    [JsonProperty("accessibility_label", NullValueHandling = NullValueHandling.Ignore)]
    public string AccessibilityLabel { get; set; }
}