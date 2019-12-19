using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    public class UpdateMessageResponse:MessageResponse
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
