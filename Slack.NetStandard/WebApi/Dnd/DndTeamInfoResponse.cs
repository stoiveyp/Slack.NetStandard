using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Dnd
{
    public class DndTeamInfoResponse:WebApiResponse {
        [JsonProperty("users",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,ApiCommon.DndStatus> Users { get; set; }
    }
}
