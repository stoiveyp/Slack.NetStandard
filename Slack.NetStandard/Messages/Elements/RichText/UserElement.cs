using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class UserElement : StyledRichTextElement
    {
        public const string ElementName = "user";

        [JsonProperty("user_id",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        public override string Type => ElementName;
    }
}