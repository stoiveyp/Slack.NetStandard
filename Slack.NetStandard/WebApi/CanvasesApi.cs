using Slack.NetStandard.WebApi.Canvases;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    internal class CanvasesApi : ICanvasesApi
    {
        private readonly IWebApiClient _client;

        public CanvasesApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<CanvasesCreateResponse> Create(string title = null, CanvasContent content = null)
        {
            return _client.MakeJsonCall<CanvasesCreateRequest, CanvasesCreateResponse>("canvases.create", new CanvasesCreateRequest { Title = title, Content = content });
        }

        public Task<WebApiResponse> Delete(string id)
        {
            return _client.SingleValueEncodedCall("canvases.delete", "canvas_id", id);
        }

        public Task<WebApiResponse> DeleteAccess(CanvasDeleteAccessRequest request)
        {
            return _client.MakeJsonCall("canvases.access.delete", request);
        }

        public Task<WebApiResponse> Edit(string canvasId, params CanvasOperation[] changes)
        {
            var req = new CanvasEditRequest
            {
                CanvasId = canvasId,
            };
            req.Changes.AddRange(changes);
            return _client.MakeJsonCall("canvases.edit", req);
        }

        public Task<SectionLookupResponse> SectionLookup(string canvasId, LookupCriteria criteria)
        {
            return _client.MakeJsonCall<CanvasSectionLookup, SectionLookupResponse>("canvases.sections.lookup", new CanvasSectionLookup
            {
                CanvasId = canvasId,
                Criteria = criteria
            });
        }

        public Task<WebApiResponse> SetAccess(CanvasSetAccessRequest request)
        {
            return _client.MakeJsonCall("canvases.access.set", request);
        }
    }
}
