using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Stars
{
    public class FileItem : StarredItem
    {
        public const string ItemType = "file";
        [JsonProperty("file",NullValueHandling = NullValueHandling.Ignore)]
        public File File { get; set; }
    }
}