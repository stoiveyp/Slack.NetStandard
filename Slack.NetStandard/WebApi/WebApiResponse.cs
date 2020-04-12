﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi
{
    public class WebApiResponse:WebApiResponse<WebApiResponseMessages>
    {
        public static WebApiResponse Success()
        {
            return new WebApiResponse {OK = true};
        }
    }

    public class WebApiResponse<TMetadata> where TMetadata: WebApiResponseMessages
    {
        [JsonProperty("ok")]
        public bool OK { get; set; }

        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }

        [JsonProperty("warning", NullValueHandling = NullValueHandling.Ignore)]
        public string Warning { get; set; }

        [JsonProperty("response_metadata", NullValueHandling = NullValueHandling.Ignore)]
        public TMetadata ResponseMetadata { get; set; }
    }
}
