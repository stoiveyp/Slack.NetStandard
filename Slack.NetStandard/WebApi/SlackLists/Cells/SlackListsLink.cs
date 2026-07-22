using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class SlackListsLink
    {
        public SlackListsLink() { }

        [JsonProperty("original_url")]
        public string OriginalUrl { get; set; }

        [JsonProperty("display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("display_as_url", NullValueHandling = NullValueHandling.Ignore)]
        public bool DisplayAsUrl { get; set; }

        [JsonProperty("attachment", NullValueHandling = NullValueHandling.Ignore)]
        public JObject Attachment { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }
    }
}