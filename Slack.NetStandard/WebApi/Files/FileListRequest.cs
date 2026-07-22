using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Files
{
    public class FileListRequest : FileRemoteListRequest
    {
        [JsonProperty("show_files_hidden_by_limit", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowFilesHiddenByLimit { get; set; }

        [JsonProperty("types", NullValueHandling = NullValueHandling.Ignore)]
        public string Types { get; set; }

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }
        
        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }
    }
}