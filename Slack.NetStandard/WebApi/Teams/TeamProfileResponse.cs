using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Teams
{
    public class TeamProfileResponse:WebApiResponse
    {
        [JsonProperty("profile",NullValueHandling = NullValueHandling.Ignore)]
        public TeamProfile Profile { get; set; }
    }
}