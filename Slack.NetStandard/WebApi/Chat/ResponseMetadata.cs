using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    public class ResponseMetadata
    {
        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
 
    }
}