using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public class MessageContainer
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("message_ts")]
        public string MessageTimestamp { get; set; }

        [JsonProperty("attachment_id")]
        public int AttachmentId { get; set; }

        [JsonProperty("channel_id")]
        public string Channel { get; set; }

        [JsonProperty("is_ephemeral")]
        public bool Ephemeral { get; set; }

        [JsonProperty("is_app_unfurl")]
        public bool AppUnfurl { get; set; }

        //"container": {
        //    "type": "message_attachment",
        //    "message_ts": "1548261231.000200",
        //    "attachment_id": 1,
        //    "channel_id": "CBR2V3XEX",
        //    "is_ephemeral": false,
        //    "is_app_unfurl": false
        //},
    }
}