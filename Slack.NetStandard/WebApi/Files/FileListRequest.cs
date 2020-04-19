using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Files
{
    public class FileListRequest
    {
        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        [JsonProperty("show_files_hidden_by_limit",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowFilesHidenByLimit { get; set; }

        [JsonProperty("ts_from",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp From { get; set; }

        [JsonProperty("ts_to",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp To { get; set; }

        [JsonProperty("types",NullValueHandling = NullValueHandling.Ignore)]
        public string Types { get; set; }

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }
    }
}
