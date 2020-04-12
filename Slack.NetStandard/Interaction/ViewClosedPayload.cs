using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Objects;

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
