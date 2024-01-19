using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.Messages.Elements.RichText;

public class TeamElement : StyledRichTextElement
{
    public const string ElementName = "team";

    [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
    public string TeamId { get; set; }

    public override string Type => ElementName;
}