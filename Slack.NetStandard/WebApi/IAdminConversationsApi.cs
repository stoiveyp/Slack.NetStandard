using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;
using CreateConversationRequest = Slack.NetStandard.WebApi.Admin.CreateConversationRequest;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminConversationsApi
    {
        Task<WebApiResponse> Archive(string channelId);
        Task<WebApiResponse> Unarchive(string channelId);
        Task<BulkActionResponse> BulkArchive(IEnumerable<string> channelIds);
        Task<BulkActionResponse> BulkDelete(IEnumerable<string> channelIds);
        Task<BulkActionResponse> BulkMove(string targetTeamId, IEnumerable<string> channelIds);
        Task<WebApiResponse> SetTeams(SetTeamsRequest request);
        Task<WebApiResponse> ConvertToPublic(string channelId);
        Task<WebApiResponse> ConvertToPrivate(string channelId);
        Task<CreateConversationResponse> Create(CreateConversationRequest request);
        Task<WebApiResponse> Delete(string channelId);
        Task<WebApiResponse> DisconnectShared(string channelId, IEnumerable<string> leavingTeamsId = null);
        Task<ConversationPrefsResponse> GetConversationPrefs(string channelId);
        Task<CustomRetentionResponse> GetCustomRetention(string channelId);
        Task<GetTeamsResponse> GetTeams(string channelId, string cursor = null, int? limit = null);
        Task<WebApiResponse> Invite(string channelId, IEnumerable<string> userIds);
        Task<LookupResponse> Lookup(LookupRequest request);
        Task<WebApiResponse> RemoveCustomRetention(string channelId);
        Task<WebApiResponse> Rename(string channelId, string name);
        Task<SearchConversationResponse> Search(SearchConversationRequest request);
        Task<WebApiResponse> SetConversationPrefs(string channelId, SetConversationPrefsRequest request);
        Task<WebApiResponse> SetCustomRetention(string channelId, int durationDays);
        Task<EkmOriginalConnectedResponse> EkmListOriginalConnectedChannelInfo(EkmOriginalConnectedRequest request);
        Task<WebApiResponse> RestrictAccessAddGroup(string channelId, string groupId, string teamId = null);
        Task<WebApiResponse> RestrictAccessRemoveGroup(string channelId, string groupId, string teamId = null);
        Task<RestrictedAccessListResponse> RestrictAccessListGroups(string channelId, string teamId = null);
    }
}