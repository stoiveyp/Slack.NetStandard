using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields;

public class ImageField : EntityPayloadField
{
    public const string TypeName = "slack#/types/image";
    [JsonProperty("type")]
    public override string Type => TypeName;

    public ImageField() { }
    public ImageField(string imageUrl) { ImageUrl = imageUrl; }
    public ImageField(SlackFile slackFile) { SlackFile = slackFile; }

    [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
    public string ImageUrl { get; set; }

    [JsonProperty("slack_file", NullValueHandling = NullValueHandling.Ignore)]
    public SlackFile SlackFile { get; set; }

    [JsonProperty("alt_text", NullValueHandling = NullValueHandling.Ignore)]
    public string AltText { get; set; }
}