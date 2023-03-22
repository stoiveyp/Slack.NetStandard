using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Stars
{
    public class FileItem : StarredItem
    {
        public const string ItemType = "file";
        [JsonProperty("file",NullValueHandling = NullValueHandling.Ignore)]
        public File File { get; set; }
    }
}