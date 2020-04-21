using System;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.View;

namespace Slack.NetStandard.WebApi
{
    internal class ViewApi:IViewApi
    {
        private readonly IWebApiClient _client;
        public ViewApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<ViewResponse> Publish(string user, Objects.View view, string hash = null)
        {
            return _client.MakeJsonCall<PublishViewRequest,ViewResponse>("views.publish", new PublishViewRequest {User = user, View = view, Hash = hash});
        }

        public Task<ViewResponse> Open(string trigger, Objects.View view)
        {
            return _client.MakeJsonCall<TriggerViewRequest, ViewResponse>("views.open", new TriggerViewRequest { Trigger = trigger, View = view });
        }

        public Task<ViewResponse> Push(string trigger, Objects.View view)
        {
            return _client.MakeJsonCall<TriggerViewRequest, ViewResponse>("views.push", new TriggerViewRequest { Trigger = trigger, View = view });
        }

        public Task<ViewResponse> UpdateByExternalId(string externalId, Objects.View view, string hash = null)
        {
            return _client.MakeJsonCall<UpdateViewRequest, ViewResponse>("views.update", new UpdateViewRequest { ExternalId = externalId, View = view, Hash = hash });
        }

        public Task<ViewResponse> UpdateByViewId(string viewId, Objects.View view, string hash = null)
        {
            return _client.MakeJsonCall<UpdateViewRequest, ViewResponse>("views.update", new UpdateViewRequest { ViewId = viewId, View = view, Hash = hash });
        }
    }
}
