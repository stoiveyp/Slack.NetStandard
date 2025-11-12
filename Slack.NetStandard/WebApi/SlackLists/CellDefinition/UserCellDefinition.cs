using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class UserCellDefinition : SlackListCellDefinition
    {
        public UserCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public UserCellDefinition(string columnId, List<string> userIds, string rowId = null) : this(columnId, rowId)
        {
            UserIds = userIds;
        }

        [JsonProperty("user")]
        public List<string> UserIds { get; private set; } = new();

        public bool ShouldSerializeUserIds() => true;
    }
}
