using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.WebApi.Admin
{
    [JsonConverter(typeof(EmojiConverter))]
    public class Emoji
    {
        public string Value { get; set; }
        public Dictionary<string,string> Values { get; set; }

        public bool IsAlias => Value?.StartsWith("alias:") ?? false;
        public string AliasFor => IsAlias ? Value.Substring(6) : null;
    }
}