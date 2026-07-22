using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists
{
    [JsonConverter(typeof(SlackListsReferenceConverter))]
    public class SlackListsReference
    {
        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; } = new();
    }
}
