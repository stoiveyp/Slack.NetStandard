using System.IO;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Files
{
    public class FileUploadRequest
    {
        [JsonProperty("channels",NullValueHandling = NullValueHandling.Ignore)]
        public string Channels { get; set; }

        [JsonProperty("content",NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonIgnore]
        public Stream File { get; set; }

        [JsonProperty("filename",NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }

        [JsonProperty("filetype",NullValueHandling = NullValueHandling.Ignore)]
        public string Filetype { get; set; }

        [JsonProperty("initial_comment",NullValueHandling = NullValueHandling.Ignore)]
        public string InitialComment { get; set; }

        [JsonProperty("thread_ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp ThreadTimestamp { get; set; }

        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

    }

    public class AddFileRemoteRequest
    {
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("external_url")]
        public string ExternalUrl { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("filetype",NullValueHandling = NullValueHandling.Ignore)]
        public string Filetype { get; set; }

        [JsonIgnore]
        public Stream IndexableFileContents { get; set; }

        [JsonIgnore]
        public Stream PreviewImage { get; set; }
    }
}