using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi
{
    public class ResponseMetadataCursor:ResponseMetadata
    {
        [JsonProperty("next_cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string NextCursor { get; set; }
    }
}