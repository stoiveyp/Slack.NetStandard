using Newtonsoft.Json;
using System;

namespace Slack.NetStandard.WebApi.Teams;

public class PreferenceListResponse : WebApiResponse
{
    [JsonProperty("display_real_names",NullValueHandling = NullValueHandling.Ignore)]
    public bool? DisplayRealNames { get; set; }

    [JsonProperty("disable_file_uploads",NullValueHandling = NullValueHandling.Ignore)]
    public string DisableFileUploads { get; set; }

    [JsonProperty("msg_edit_window_mins",NullValueHandling = NullValueHandling.Ignore)]
    public int MsgEditWindowMins { get; set; }

    [JsonProperty("who_can_post_general",NullValueHandling = NullValueHandling.Ignore)]
    public string WhoCanPostGeneral { get; set; }
}