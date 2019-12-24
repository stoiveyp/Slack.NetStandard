using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi
{
    public class WebApiResponse
    {
        public static WebApiResponse Success()
        {
            return new WebApiResponse {OK = true};
        }

        [JsonProperty("ok")]
        public bool OK { get; set; }

        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }

        [JsonProperty("warning", NullValueHandling = NullValueHandling.Ignore)]
        public string Warning { get; set; }
    }
}
