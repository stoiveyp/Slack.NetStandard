﻿using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ListTeamsResponse:WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("teams",NullValueHandling = NullValueHandling.Ignore)]
        public ListedTeam[] Teams { get; set; }
    }
}