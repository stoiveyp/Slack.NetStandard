using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class WorkflowPermissionLookupResponse:WebApiResponse
    {
        [JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, WorkflowPermissionLookup> Permissions { get; set; } = new();

        public bool ShouldSerializePermissions() => Permissions?.Any() ?? false;
    }
}
