using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Workflow
{
    internal class Error
    {
        [JsonProperty("message",NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }
}