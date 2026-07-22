using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

public interface IAdminUsergroupsApi
{
    Task<ModifyChannelResponse> AddChannels(IEnumerable<string> channelIds, string usergroupId, string teamId = null);
    Task<WebApiResponse> AddTeams(IEnumerable<string> teamIds, string usergroupId, bool? autoProvision = null);
    Task<ModifyChannelResponse> RemoveChannels(IEnumerable<string> channelIds, string usergroupId);
    Task<ListChannelResponse> ListChannels(string usergroupId, bool? includeNumMembers = null, string teamId = null);
}