using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Stars
{
    public class StarredFileItem : StarredItem
    {
        [JsonProperty("file",NullValueHandling = NullValueHandling.Ignore)]
        public File File { get; set; }
    }
}