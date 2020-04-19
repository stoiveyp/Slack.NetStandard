using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Files
{
    public class FileResponse:WebApiResponse
    {
        [JsonProperty("file",NullValueHandling = NullValueHandling.Ignore)]
        public File File { get; set; }
    }
}
