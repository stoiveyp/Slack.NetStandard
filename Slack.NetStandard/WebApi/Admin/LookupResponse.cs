﻿using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class LookupResponse : WebApiResponse<ResponseMetadataCursor>
{
    [JsonProperty("channels")]
    public string[] Channels { get; set; }
}