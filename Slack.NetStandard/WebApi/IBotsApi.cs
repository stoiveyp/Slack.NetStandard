using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Bots;

namespace Slack.NetStandard.WebApi
{
    public interface IBotsApi
    {
        Task<InfoResponse> Info(string bot = null);
    }
}