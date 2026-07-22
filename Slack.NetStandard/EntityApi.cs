using Slack.NetStandard.WebApi;
using Slack.NetStandard.WebApi.Entity;
using System.Threading.Tasks;

namespace Slack.NetStandard
{
    internal class EntityApi : IEntityApi
    {
        private readonly IWebApiClient _client;

        public EntityApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WebApiResponse> PresentDetails(PresentDetailsRequest request)
        {
            return _client.MakeJsonCall("entity.presentDetails", request);
        }
    }
}