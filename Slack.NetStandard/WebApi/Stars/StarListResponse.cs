using System;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Stars
{
    public class StarListResponse:WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("items",NullValueHandling = NullValueHandling.Ignore)]
        public StarredItem[] Items { get; set; }
    }
}
