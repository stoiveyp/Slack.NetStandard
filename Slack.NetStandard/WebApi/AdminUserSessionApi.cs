using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

internal class AdminUserSessionApi : IAdminUserSessionApi
{
    private readonly IWebApiClient _client;

    public AdminUserSessionApi(IWebApiClient client)
    {
        _client = client;
    }

    public Task<WebApiResponse> ClearSettings(string[] userIds)
    {
        var jo = new JObject(new JProperty("user_ids",new JArray(userIds)));
        return _client.MakeJsonCall("admin.users.session.clearSettings", jo);
    }

    public Task<GetSettingsResponse> GetSettings(string[] userIds)
    {
        var jo = new JObject(new JProperty("user_ids", new JArray(userIds)));
        return _client.MakeJsonCall<JObject,GetSettingsResponse>("admin.users.session.getSettings", jo);
    }

    public Task<WebApiResponse> Reset(string userId, SessionType type)
    {
        var dict = new Dictionary<string, string> { { "user_id", userId } };

        if (type == SessionType.MobileOnly)
        {
            dict.Add("mobile_only", true.ToString().ToLower());
        }

        if (type == SessionType.WebOnly)
        {
            dict.Add("web_only", true.ToString().ToLower());
        }

        return _client.MakeUrlEncodedCall("admin.users.session.reset", dict);
    }

    public Task<WebApiResponse> ResetBulk(string[] userIds, SessionType type)
    {
        var jo = new JObject(new JProperty("user_ids",new JArray(userIds)));

        if (type == SessionType.MobileOnly)
        {
            jo.Add("mobile_only", true);
        }

        if (type == SessionType.WebOnly)
        {
            jo.Add("web_only", true);
        }

        return _client.MakeJsonCall("admin.users.session.resetBulk", jo);
    }

    public Task<WebApiResponse> Invalidate(string sessionId, string teamId)
    {
        var jo = new JObject(
            new JProperty("session_id", sessionId),
            new JProperty("team_id", teamId)
            );
        return _client.MakeJsonCall("admin.users.session.invalidate", jo);
    }

    public Task<ListSessionResponse> List(ListSessionRequest request)
    {
        return _client.MakeJsonCall<ListSessionRequest, ListSessionResponse>("admin.users.session.list", request);
    }

    public Task<WebApiResponse> SetSettings(string[] userIds, bool? desktopAppBrowserQuit = null, long? duration = null)
    {
        var jo = new JObject(new JProperty("user_ids", new JArray(userIds)));
        jo.AddIfValue("desktop_app_browser_quit", desktopAppBrowserQuit);
        jo.AddIfValue("duration", duration);
        return _client.MakeJsonCall("admin.users.session.setSettings", jo);
    }
}