using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class MessageCellDefinition : SlackListsCellDefinition
    {
        public MessageCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public MessageCellDefinition(string columnId, List<string> messages, string rowId = null) : this(columnId, rowId)
        {
            Messages = messages;
        }

        [JsonProperty("message")]
        public List<string> Messages { get; private set; } = new();

        public bool ShouldSerializeMessages() => true;
    }
}
