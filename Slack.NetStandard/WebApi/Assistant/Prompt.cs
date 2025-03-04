using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.WebApi.Assistant
{
    public class Prompt
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
