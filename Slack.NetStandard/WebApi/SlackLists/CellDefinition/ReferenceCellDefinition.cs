using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class ReferenceCellDefinition : SlackListsCellDefinition
    {
        public ReferenceCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public ReferenceCellDefinition(string columnId, List<SlackListsReference> references, string rowId = null) : this(columnId, rowId)
        {
            References = references;
        }

        [JsonProperty("reference")]
        public List<SlackListsReference> References { get; private set; } = new();

        public bool ShouldSerializeReferences() => true;
    }
}
