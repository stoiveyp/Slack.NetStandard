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

        public Task<ViewResponse> Publish(string userId, Objects.View view, string hash = null)
        {
            return _client.MakeJsonCall<PublishViewRequest,ViewResponse>("views.publish", new PublishViewRequest {User = userId, View = view, Hash = hash});
        }
    }
}
