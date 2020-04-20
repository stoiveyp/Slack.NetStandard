using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Files
{
    public class FileRemoteListRequest
    {
        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        [JsonProperty("ts_from", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp From { get; set; }

        [JsonProperty("ts_to", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp To { get; set; }
    }
}