using Slack.NetStandard.WebApi.Workflows;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    internal class WorkflowsFeaturedApi : IWorkflowsFeaturedApi
    {
        private readonly IWebApiClient _client;

        public WorkflowsFeaturedApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WebApiResponse> Add(string channelId, List<string> triggerIds)
        {
            return _client.MakeJsonCall<FeaturedWorkflowManipulationRequest, WebApiResponse>(
                "workflows.featured.add",
                new(channelId, triggerIds));
        }

        public Task<WebApiResponse> Add(string channelId, params string[] triggerIds)
        {
            return Add(channelId, triggerIds.ToList());
        }

        public Task<FeaturedWorkflowListResponse> List(List<string> channelIds)
        {
            return _client.MakeJsonCall<FeaturedWorkflowListRequest, FeaturedWorkflowListResponse>(
                "workflows.featured.list",
                new(channelIds));
        }

        public Task<FeaturedWorkflowListResponse> List(params string[] channelIds)
        {
            return List(channelIds.ToList());
        }

        public Task<WebApiResponse> Remove(string channelId, List<string> triggerIds)
        {
            return _client.MakeJsonCall<FeaturedWorkflowManipulationRequest, WebApiResponse>(
                "workflows.featured.remove",
                new(channelId, triggerIds));
        }

        public Task<WebApiResponse> Remove(string channelId, params string[] triggerIds)
        {
            return Remove(channelId, triggerIds.ToList());
        }

        public Task<WebApiResponse> Set(string channelId, List<string> triggerIds)
        {
            return _client.MakeJsonCall<FeaturedWorkflowManipulationRequest, WebApiResponse>(
                "workflows.featured.set",
                new(channelId, triggerIds));
        }

        public Task<WebApiResponse> Set(string channelId, params string[] triggerIds)
        {
            return Set(channelId, triggerIds.ToList());
        }
    }
}