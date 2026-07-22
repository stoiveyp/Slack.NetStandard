using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class SlackListsLinkDefinition
    {
        public SlackListsLinkDefinition() { }

        public SlackListsLinkDefinition(string url, string name = null, bool displayAsUrl = false)
        {
            Url = url;
            Name = name;
            DisplayAsUrl = displayAsUrl;
        }

        [JsonProperty("original_url")]
        public string Url { get; set; }

        [JsonProperty("display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("display_as_url", NullValueHandling = NullValueHandling.Ignore)]
        public bool DisplayAsUrl { get; set; }
    }
}
