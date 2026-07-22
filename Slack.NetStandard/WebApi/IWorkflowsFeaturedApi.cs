using Slack.NetStandard.WebApi.Workflows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface IWorkflowsFeaturedApi
    {
        Task<WebApiResponse> Add(string channelId, List<string> triggerIds);
        Task<WebApiResponse> Add(string channelId, params string[] triggerIds);
        Task<WebApiResponse> Remove(string channelId, List<string> triggerIds);
        Task<WebApiResponse> Remove(string channelId, params string[] triggerIds);
        Task<FeaturedWorkflowListResponse> List(List<string> channelIds);
        Task<FeaturedWorkflowListResponse> List(params string[] channelIds);
        Task<WebApiResponse> Set(string channelId, List<string> triggerIds);
        Task<WebApiResponse> Set(string channelId, params string[] triggerIds);
    }
}