using System.IO;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Files
{
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