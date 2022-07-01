using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.Messages.Elements
{
    public class Filter
    {
        [JsonProperty("include", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Include { get; set; } = new List<string>();

        [JsonProperty("exclude_bot_users",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExcludeBotUsers { get; set; }

        [JsonProperty("exclude_external_shared_channels",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExcludeExternalSharedChannels { get; set; }

        public bool ShouldSerializeInclude() => Include?.Any() ?? false;
    }
}