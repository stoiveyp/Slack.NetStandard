using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

public class AdminUsergroupsApi : IAdminUsergroupsApi
{
    private readonly IWebApiClient _client;
    public AdminUsergroupsApi(IWebApiClient client)
    {
        _client = client;
    }

    public Task<ModifyChannelResponse> AddChannels(IEnumerable<string> channelIds, string usergroupId, string teamId = null)
    {
        var jo = new JObject(
            new JProperty("channel_ids", new JArray(channelIds.ToArray())),
            new JProperty("usergroup_id",usergroupId)
            );
        jo.AddIfValue("team_id", teamId);
        return _client.MakeJsonCall<JObject, ModifyChannelResponse>("admin.usergroups.addChannels", jo);
    }

    public Task<WebApiResponse> AddTeams(IEnumerable<string> teamIds, string usergroupId, bool? autoProvision = null)
    {
        var jo = new JObject(
            new JProperty("team_ids", new JArray(teamIds.ToArray())),
            new JProperty("usergroup_id", usergroupId)
        );
        jo.AddIfValue("auto_provision", autoProvision);
        return _client.MakeJsonCall<JObject, WebApiResponse>("admin.usergroups.addTeams", jo);
    }

    public Task<ModifyChannelResponse> RemoveChannels(IEnumerable<string> channelIds, string usergroupId)
    {
        var jo = new JObject(
            new JProperty("channel_ids", new JArray(channelIds.ToArray())),
            new JProperty("usergroup_id", usergroupId)
        );
        return _client.MakeJsonCall<JObject, ModifyChannelResponse>("admin.usergroups.removeChannels", jo);
    }

    public Task<ListChannelResponse> ListChannels(string usergroupId, bool? includeNumMembers = null, string teamId = null)
    {
        var jo = new JObject(new JProperty("usergroup_id", usergroupId));
        jo.AddIfValue("include_num_members", includeNumMembers);
        jo.AddIfValue("team_id", teamId);
        return _client.MakeJsonCall<JObject, ListChannelResponse>("admin.usergroups.listChannels", jo);
    }
}