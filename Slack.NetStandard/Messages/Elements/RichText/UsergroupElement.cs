using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements.RichText;

public class UsergroupElement : RichTextElement
{
    public const string ElementName = "usergroup";

    [JsonProperty("usergroup_id",NullValueHandling = NullValueHandling.Ignore)]
    public string UsergroupId { get; set; }
}