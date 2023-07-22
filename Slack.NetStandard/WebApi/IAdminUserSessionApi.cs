using Slack.NetStandard.WebApi.Admin;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi;

public interface IAdminUserSessionApi
{
    Task<WebApiResponse> ClearSettings(string[] userIds);
    Task<GetSettingsResponse> GetSettings(string[] userIds);
    Task<WebApiResponse> Reset(string userId, SessionType type);
    Task<WebApiResponse> ResetBulk(string[] userIds, SessionType type);
    Task<WebApiResponse> Invalidate(string sessionId, string teamId);
    Task<ListSessionResponse> List(ListSessionRequest request);
    Task<WebApiResponse> SetSettings(string[] userIds, bool? desktopAppBrowserQuit = null, long? duration = null);
}