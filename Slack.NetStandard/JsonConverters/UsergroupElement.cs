using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements.RichText;

namespace Slack.NetStandard.JsonConverters
{
    public class UsergroupElement : RichTextElement
    {
        public const string ElementName = "usergroup";

        [JsonProperty("usergroup_id",NullValueHandling = NullValueHandling.Ignore)]
        public string Usergroup { get; set; }
    }
}