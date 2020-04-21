using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ListOwnersResponse : WebApiResponse<ResponseMetadataCursor>
    {
        [JsonProperty("owners_ids", NullValueHandling = NullValueHandling.Ignore)]
        public string[] OwnerIds { get; set; }
    }
}