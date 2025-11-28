using Newtonsoft.Json;
using Slack.NetStandard.WebApi.SlackLists.Cells;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class MessageCellDefinition : SlackListsCellDefinition
    {
        public MessageCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public MessageCellDefinition(string columnId, List<SlackListsMessageInfo> messages, string rowId = null) : this(columnId, rowId)
        {
            Messages = messages;
        }

        [JsonProperty("message")]
        public List<SlackListsMessageInfo> Messages { get; private set; } = new();

        public bool ShouldSerializeMessages() => true;
    }
}
