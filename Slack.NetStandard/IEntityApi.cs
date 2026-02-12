using Slack.NetStandard.WebApi;
using Slack.NetStandard.WebApi.Entity;
using System.Threading.Tasks;

namespace Slack.NetStandard
{
    public interface IEntityApi
    {
        Task<WebApiResponse> PresentDetails(PresentDetailsRequest request);
    }
}