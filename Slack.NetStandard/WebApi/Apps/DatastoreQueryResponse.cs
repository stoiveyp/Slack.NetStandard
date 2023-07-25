using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class DatastoreQueryResponse : WebApiResponse<ResponseMetadataCursor>
{
    [JsonProperty("datastore",NullValueHandling = NullValueHandling.Ignore)]
    public string Datastore { get; set; }

    [JsonProperty("items",NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string,object>[] Items { get; set; }
}