using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Apps;

namespace Slack.NetStandard.WebApi;

internal class AppsDatastoreApi : IAppsDataStoreApi
{
    private readonly IWebApiClient _client;

    public AppsDatastoreApi(IWebApiClient client)
    {
        _client = client;
    }

    public Task<DatastoreItemResponse> Get(string datastore, string itemId)
    {
        var jo = new JObject(new JProperty("datastore", datastore), new JProperty("id", itemId));
        return _client.MakeJsonCall<JObject, DatastoreItemResponse>("apps.datastore.get", jo);
    }

    public Task<DatastoreItemResponse> Put(string datastore, Dictionary<string, object> item, string appId = null)
    {
        var jo = new JObject(
            new JProperty("datastore", datastore), 
            new JProperty("item", JObject.FromObject(item)));

        if (!string.IsNullOrWhiteSpace(appId))
        {
            jo.Add(new JProperty("app_id",appId));
        }

        return _client.MakeJsonCall<JObject, DatastoreItemResponse>("apps.datastore.put", jo);
    }

    public Task<DatastoreItemResponse> Update(string datastore, Dictionary<string, object> item, string appId = null)
    {
        var jo = new JObject(
            new JProperty("datastore", datastore),
            new JProperty("item", JObject.FromObject(item)));

        if (!string.IsNullOrWhiteSpace(appId))
        {
            jo.Add(new JProperty("app_id", appId));
        }

        return _client.MakeJsonCall<JObject, DatastoreItemResponse>("apps.datastore.update", jo);
    }

    public Task<DatastoreQueryResponse> Query(DatastoreQueryRequest request)
    {
        return _client.MakeJsonCall<DatastoreQueryRequest, DatastoreQueryResponse>("apps.datastore.query", request);
    }
}