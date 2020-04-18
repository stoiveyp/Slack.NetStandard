using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    internal class AppsApi : IAppsApi
    {
        private readonly IWebApiClient _client;

        public AppsApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WebApiResponse> Uninstall(string clientId, string clientSecret)
        {
            return _client.MakeUrlEncodedCall("apps.uninstall", new Dictionary<string, string>
            {
                {"client_id", clientId},
                {"client_secret", clientSecret}
            });
        }
    }
}