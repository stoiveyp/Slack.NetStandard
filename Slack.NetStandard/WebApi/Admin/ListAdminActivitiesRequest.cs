using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ListAdminActivitiesRequest : ListActivitiesRequestBase
    {
        [JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }
    }
}
