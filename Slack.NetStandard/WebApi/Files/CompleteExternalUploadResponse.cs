using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Files;

public class CompleteExternalUploadResponse : WebApiResponse
{
    [JsonProperty("files",NullValueHandling = NullValueHandling.Ignore)]
    public CompletedFile[] Files { get; set; }
}