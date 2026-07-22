using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class DatastoreQueryRequest
{
    public DatastoreQueryRequest(string datastore)
    {
        Datastore = datastore;
    }

    [JsonProperty("datastore")]
    public string Datastore { get; set; }

    [JsonProperty("app_id",NullValueHandling = NullValueHandling.Ignore)]
    public string AppId { get; set; }

    [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
    public string Cursor { get; set; }

    [JsonProperty("expression",NullValueHandling = NullValueHandling.Ignore)]
    public string Expression { get; set; }

    [JsonProperty("expression_attributes",NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string,object> ExpressionAttributes { get; set; }

    [JsonProperty("expression_values",NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string,object> ExpressionValues { get; set; }

    [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }
}