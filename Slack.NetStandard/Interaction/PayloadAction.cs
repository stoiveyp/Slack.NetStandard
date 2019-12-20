using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.Interaction
{
    public class PayloadAction
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("text",NullValueHandling = NullValueHandling.Ignore)]
        public TextObject Text { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("action_ts")]
        public string ActionTimestamp { get; set; }



        //{
        //    "type":"button",
        //    "block_id":"7fhg",
        //    "action_id":"XRX",
        //    "text":{
        //        "type":"plain_text",
        //        "text":"Action A",
        //        "emoji":true
        //    },
        //    "action_ts":"1571318425.267782"
        //}

        //{
        //    "action_id": "WaXA",
        //    "block_id": "=qXel",
        //    "text": {
        //        "type": "plain_text",
        //        "text": "View",
        //        "emoji": true
        //    },
        //    "value": "click_me_123",
        //    "type": "button",
        //    "action_ts": "1548426417.840180"
        //}
}
}