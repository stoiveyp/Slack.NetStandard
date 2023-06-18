using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminConversationsApi
    {
        Task<WebApiResponse> Archive(string channelId);
        Task<BulkActionResponse> BulkArchive(IEnumerable<string> channelIds);
        Task<BulkActionResponse> BulkDelete(IEnumerable<string> channelIds);
        Task<BulkActionResponse> BulkMove(string targetTeamId, IEnumerable<string> channelIds);
        Task<WebApiResponse> SetTeams(SetTeamsRequest request);
    }
}