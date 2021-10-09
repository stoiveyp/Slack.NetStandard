using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Apps;
using Slack.NetStandard.WebApi.Apps.Manifest;

namespace Slack.NetStandard.WebApi;

internal class AppsManifestApi : IAppsManifestApi
{
    private readonly IWebApiClient _client;

    public AppsManifestApi(IWebApiClient client)
    {
        _client = client;
    }

    public Task<CreateManifestResponse> Create(ManifestDefinition manifestDefinition)
    {
        throw new System.NotImplementedException();
    }

    public Task<CreateManifestResponse> Create(string manifest)
    {
        throw new System.NotImplementedException();
    }

    public Task<UpdateManifestResponse> Update(string appId, ManifestDefinition manifestDefinition)
    {
        throw new System.NotImplementedException();
    }

    public Task<UpdateManifestResponse> Update(string appId, string manifest)
    {
        throw new System.NotImplementedException();
    }

    public Task<WebApiResponse> Delete(string appId)
    {
        throw new System.NotImplementedException();
    }

    public Task<ExportManifestResponse> Export(string appId)
    {
        return _client.MakeUrlEncodedCall<ExportManifestResponse>("apps.manifest.export",
            new() { { "app_id", appId } });
    }

    public Task<WebApiResponse> Validate(ManifestDefinition manifestDefinition)
    {
        throw new System.NotImplementedException();
    }

    public Task<WebApiResponse> Validate(string manifest)
    {
        throw new System.NotImplementedException();
    }
}