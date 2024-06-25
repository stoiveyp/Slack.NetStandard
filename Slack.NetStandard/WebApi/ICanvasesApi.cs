using Slack.NetStandard.WebApi.Canvases;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface ICanvasesApi
    {
        Task<CanvasesCreateResponse> Create(string title = null, CanvasContent content = null);
        Task<WebApiResponse> Delete(string id);
        Task<WebApiResponse> SetAccess(CanvasSetAccessRequest request);
        Task<WebApiResponse> DeleteAccess(CanvasDeleteAccessRequest request);
    }
}
