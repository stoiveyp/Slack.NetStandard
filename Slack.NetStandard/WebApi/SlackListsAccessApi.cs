using Slack.NetStandard.WebApi.SlackLists;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    internal class SlackListsAccessApi : ISlackListsAccessApi
    {
        private readonly IWebApiClient _client;

        public SlackListsAccessApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WebApiResponse> DeleteChannels(string listId, params string[] channelIds)
        {
            throw new System.NotImplementedException();
        }

        public Task<WebApiResponse> DeleteChannels(string listId, List<string> channelIds)
        {
            throw new System.NotImplementedException();
        }

        public Task<WebApiResponse> DeleteUsers(string listId, params string[] userIds)
        {
            throw new System.NotImplementedException();
        }

        public Task<WebApiResponse> DeleteUsers(string listId, List<string> userIds)
        {
            throw new System.NotImplementedException();
        }

        public Task<WebApiResponse> SetChannels(string listId, ListAccessLevel level, params string[] channelIds)
        {
            throw new System.NotImplementedException();
        }

        public Task<WebApiResponse> SetChannels(string listId, ListAccessLevel level, List<string> channelIds)
        {
            throw new System.NotImplementedException();
        }

        public Task<WebApiResponse> SetUsers(string listId, ListAccessLevel level, params string[] userIds)
        {
            throw new System.NotImplementedException();
        }

        public Task<WebApiResponse> SetUsers(string listId, ListAccessLevel level, List<string> userIds)
        {
            throw new System.NotImplementedException();
        }
    }
}