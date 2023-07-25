using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps
{
    public class CreateManifestResponse:WebApiResponse
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("oauth_authorize_url", NullValueHandling = NullValueHandling.Ignore)]
        public string OAuthAuthorizeUrl { get; set; }

        [JsonProperty("credentials",NullValueHandling = NullValueHandling.Ignore)]
        public OAuthCredentials Credentials { get; set; }
    }
}
