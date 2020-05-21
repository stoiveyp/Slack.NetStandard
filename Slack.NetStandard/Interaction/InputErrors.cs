using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public class InputErrors
    {
        [JsonProperty("errors")]
        public ErrorInformation[] Errors { get; set; }
    }
}
