using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class BulkActionResponse:WebApiResponse
    {
        [JsonProperty("bulk_action_id",NullValueHandling = NullValueHandling.Ignore)]
        public string BulkActionId { get; set; }

        [JsonProperty("not_added",NullValueHandling = NullValueHandling.Ignore)]
        public BulkActionItem[] NotAdded { get; set; }
    }
}
