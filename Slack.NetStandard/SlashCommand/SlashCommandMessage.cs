using Slack.NetStandard.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.SlashCommand
{
    public class SlashCommandMessage:Message
    {
        public SlashCommandMessage() :this(ResponseType.Ephemeral){ }

        public SlashCommandMessage(ResponseType responseType)
        {
            ResponseType = responseType;
        }

        [JsonProperty("response_type"),JsonConverter(typeof(StringEnumConverter))]
        public ResponseType ResponseType { get; set; }
    }
}
