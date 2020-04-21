using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Usergroups
{
    public class UsergroupResponse:WebApiResponse
    {
        [JsonProperty("usergroup",NullValueHandling = NullValueHandling.Ignore)]
        public Usergroup Usergroup { get; set; }
    }

    public class UsergroupListResponse : WebApiResponse
    {
        [JsonProperty("usergroups",NullValueHandling = NullValueHandling.Ignore)]
        public Usergroup[] Usergroups { get; set; }
    }
}
