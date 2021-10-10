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
}
