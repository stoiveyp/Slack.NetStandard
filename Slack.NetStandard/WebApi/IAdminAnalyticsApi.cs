using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminAnalyticsApi
    {
        Task<HttpResponseMessage> GetFile(string type, DateTime? date = null);
    }
}