using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Files;

public class GetExternalUploadUrlRequest
{
    public GetExternalUploadUrlRequest(){}

    public GetExternalUploadUrlRequest(string filename, int length)
    {
        Filename = filename;
        Length = length;
    }

    [JsonProperty("filename")]
    public string Filename { get; set; }

    [JsonProperty("length")]
    public int Length { get; set; }

    [JsonProperty("alt_txt",NullValueHandling = NullValueHandling.Ignore)]
    public string AltTxt { get; set; }

    [JsonProperty("snippet_type",NullValueHandling = NullValueHandling.Ignore)]
    public string SnippetType { get; set; }
}