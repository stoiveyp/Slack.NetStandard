using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.Interaction
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
