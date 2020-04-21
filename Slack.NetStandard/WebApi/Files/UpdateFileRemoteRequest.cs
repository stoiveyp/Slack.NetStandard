using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Files
{
    public class UpdateFileRemoteRequest:AddFileRemoteRequest
    {
        [JsonProperty("file",NullValueHandling = NullValueHandling.Ignore)]
        public string File { get; set; }
    }
}