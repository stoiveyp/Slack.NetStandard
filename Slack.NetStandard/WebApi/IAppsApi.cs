using System;
using System.Text;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface IAppsApi
    {
        Task<WebApiResponse> Uninstall(string clientId, string clientSecret);
    }
}
