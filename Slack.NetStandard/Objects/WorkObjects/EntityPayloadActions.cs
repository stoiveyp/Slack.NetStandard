using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayloadActions
    {
        [JsonProperty("primary_actions")]
        public List<EntityPayloadAction> PrimaryActions { get; set; } = new();

        [JsonProperty("overflow_actions")]
        public List<EntityPayloadAction> OverflowActions { get; set; } = new();

        public bool ShouldSerializePrimaryActions() => PrimaryActions?.Any() ?? false;
        public bool ShouldSerializeOverflowActions() => OverflowActions?.Any() ?? false;
    }
}