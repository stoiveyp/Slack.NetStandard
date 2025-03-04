using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.WebApi.Assistant
{
    public class SearchContextResults
    {
        [AcceptedArray]
        [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
        public Message[] Messages { get; set; }
    }
}