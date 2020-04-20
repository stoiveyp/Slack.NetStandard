using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class UserElement : RichTextElement
    {
        public const string ElementName = "user";

        [JsonProperty("style",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,bool> Style { get; set; }

        [JsonProperty("user_id",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }
    }
}