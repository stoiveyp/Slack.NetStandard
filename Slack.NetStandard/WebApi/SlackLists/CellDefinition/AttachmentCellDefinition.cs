using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class AttachmentCellDefinition:SlackListsCellDefinition
    {
        public AttachmentCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public AttachmentCellDefinition(string columnId, List<string> attachments, string rowId = null) : this(columnId, rowId)
        {
            Attachments = attachments;
        }

        [JsonProperty("attachment")]
        public List<string> Attachments { get; private set; } = new();

        public bool ShouldSerializeAttachments() => true;
    }
}
