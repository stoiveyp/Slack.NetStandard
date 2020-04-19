using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Files
{
    public class FileListResponse : WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("files",NullValueHandling = NullValueHandling.Ignore)]
        public File[] Files { get; set; }
    }
}