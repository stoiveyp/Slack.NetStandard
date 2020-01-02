using Slack.NetStandard.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.SlashCommand
{
    public class SlashCommandMessage:Message
    {
        public SlashCommandMessage(bool? replaceOriginal = null) :this(ResponseType.Ephemeral,replaceOriginal){ }

        public SlashCommandMessage(ResponseType responseType,bool? replaceOriginal = null)
        {
            ResponseType = responseType;
            ReplaceOriginal = replaceOriginal;
        }

        [JsonProperty("response_type"),JsonConverter(typeof(StringEnumConverter))]
        public ResponseType ResponseType { get; set; }

        [JsonProperty("replace_original",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReplaceOriginal { get; set; }
    }
}
