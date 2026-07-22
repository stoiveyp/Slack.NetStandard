using Slack.NetStandard.WebApi.SlackLists;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface ISlackListsAccessApi
    {
        Task<WebApiResponse> SetChannels(string listId, ListAccessLevel level, params string[] channelIds);
        Task<WebApiResponse> SetChannels(string listId, ListAccessLevel level, List<string> channelIds);
        Task<WebApiResponse> SetUsers(string listId, ListAccessLevel level, params string[] userIds);
        Task<WebApiResponse> SetUsers(string listId, ListAccessLevel level, List<string> userIds);

        Task<WebApiResponse> DeleteChannels(string listId, params string[] channelIds);
        Task<WebApiResponse> DeleteChannels(string listId, List<string> channelIds);
        Task<WebApiResponse> DeleteUsers(string listId, params string[] userIds);
        Task<WebApiResponse> DeleteUsers(string listId, List<string> userIds);
    }
}