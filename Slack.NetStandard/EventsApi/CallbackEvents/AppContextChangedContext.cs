using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class AppContextChangedContext
    {
        [JsonProperty("entities")]
        public List<ContextEntity> Entities { get; set; } = new List<ContextEntity>();

        public bool ShouldSerializeEntities() => Entities?.Any() ?? false;
    }
}
