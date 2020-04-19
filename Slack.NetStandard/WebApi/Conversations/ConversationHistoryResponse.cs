using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class ConversationHistoryResponse:WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("messages",NullValueHandling = NullValueHandling.Ignore)]
        public Message[] Messages { get; set; }

        [JsonProperty("has_more",NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasMore { get; set; }

        [JsonProperty("pin_count",NullValueHandling = NullValueHandling.Ignore)]
        public int? PinCount { get; set; }
    }
}
