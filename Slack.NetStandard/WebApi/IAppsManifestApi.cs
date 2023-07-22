using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Apps;
using Slack.NetStandard.WebApi.Apps.Manifest;

namespace Slack.NetStandard.WebApi
{
    public interface IAppsManifestApi
    {
        Task<CreateManifestResponse> Create(ManifestDefinition manifestDefinition);
        Task<CreateManifestResponse> Create(string manifest);

        Task<UpdateManifestResponse> Update(string appId, ManifestDefinition manifestDefinition);
        Task<UpdateManifestResponse> Update(string appId, string manifest);

        Task<WebApiResponse> Delete(string appId);
        Task<ExportManifestResponse> Export(string appId);

        Task<WebApiResponse> Validate(ManifestDefinition manifestDefinition);
        Task<WebApiResponse> Validate(string manifest);
    }

    public interface IAppsDataStoreApi
    {
        Task<DatastoreItemResponse> Get(string datastore, string itemId);
        Task<DatastoreItemResponse> Put(string datastore, Dictionary<string, object> item, string appId = null);
        Task<DatastoreItemResponse> Update(string datastore, Dictionary<string, object> item, string appId = null);
        Task<DatastoreQueryResponse> Query(DatastoreQueryRequest request);
    }
}
