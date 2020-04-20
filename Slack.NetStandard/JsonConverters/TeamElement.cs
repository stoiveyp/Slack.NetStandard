using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements.RichText;

namespace Slack.NetStandard.JsonConverters
{
    public class TeamElement : RichTextElement
    {
        public const string ElementName = "team";

        [JsonProperty("team_id")]
        public string Team { get; set; }

        [JsonProperty("style", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, bool> Style { get; set; }
    }
}