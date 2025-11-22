using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class EmailCellDefinition:SlackListsCellDefinition
    {
        public EmailCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public EmailCellDefinition(string columnId, List<string> emails, string rowId = null) : this(columnId, rowId)
        {
            Emails = emails;
        }

        [JsonProperty("email")]
        public List<string> Emails { get; private set; } = new();

        public bool ShouldSerializeEmails() => true;
    }
}
