using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Files;

public class GetExternalUploadUrlResponse:WebApiResponse
{
    [JsonProperty("upload_url",NullValueHandling = NullValueHandling.Ignore)]
    public string UploadUrl { get; set; }

    [JsonProperty("file_id",NullValueHandling = NullValueHandling.Ignore)]
    public string FileId { get; set; }
}