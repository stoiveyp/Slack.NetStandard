using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public class ViewClosedPayload:InteractionPayload
    {
        [JsonProperty("view",NullValueHandling = NullValueHandling.Ignore)]
        public View View { get; set; }

        [JsonProperty("is_cleared",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsCleared { get; set; }
    }
}
