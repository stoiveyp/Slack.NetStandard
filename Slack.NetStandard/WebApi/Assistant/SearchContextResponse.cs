using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.WebApi.Assistant
{
    public class SearchContextResponse : WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public SearchContextResults Results { get; set; }
    }
}
