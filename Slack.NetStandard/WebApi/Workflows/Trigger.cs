using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Workflows
{
    public class Trigger
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
