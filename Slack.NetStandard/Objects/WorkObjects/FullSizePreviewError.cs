using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class FullSizePreviewError
    {
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
    }
}