using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class File : IMessageBlock
    {
        public File(){}

        public File(string externalId)
        {
            ExternalId = externalId;
            Source = "remote";
        }

        [JsonProperty("type")]
        public string Type => nameof(File).ToLower();

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("source",NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("external_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalId { get; set; }
    }
}