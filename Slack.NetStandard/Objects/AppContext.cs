using Newtonsoft.Json;
using Slack.NetStandard.EventsApi.CallbackEvents;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.Objects
{
    public class AppContext
    {
        [JsonProperty("entities")]
        public List<ContextEntity> Entities { get; set; } = new List<ContextEntity>();

        public bool ShouldSerializeEntities() => Entities?.Any() ?? false;
    }
}
