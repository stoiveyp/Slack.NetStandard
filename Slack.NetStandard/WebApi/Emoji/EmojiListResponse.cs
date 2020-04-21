using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Emoji
{
    public class EmojiListResponse:WebApiResponse
    {
        [JsonProperty("emoji",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,EmojiInformation> Emoji { get; set; }
    }
}
